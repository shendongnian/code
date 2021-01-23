    public static class Rdtsc
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct SystemInfo
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern void GetNativeSystemInfo(out SystemInfo lpSystemInfo);
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr VirtualAlloc(IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool VirtualProtect(IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, out uint lpflOldProtect);
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool VirtualFree(IntPtr lpAddress, IntPtr dwSize, uint dwFreeType);
        private const uint PAGE_READWRITE = 0x04;
        private const uint PAGE_EXECUTE = 0x10;
        private const uint PAGE_EXECUTE_READWRITE = 0x40;
        private const uint MEM_COMMIT = 0x1000;
        private const uint MEM_RELEASE = 0x8000;
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate ulong FuncUInt64();
        /// <summary>
        /// Uses rdtsc. On non-Intel uses Stopwatch.GetTimestamp.
        /// </summary>
        public static readonly FuncUInt64 Timestamp;
        /// <summary>
        /// Uses rdtscp if present. Otherwise uses cpuid + rdtsc. On 
        /// non-Intel uses Stopwatch.GetTimestamp.
        /// </summary>
        public static readonly FuncUInt64 TimestampP;
        public static readonly bool IsRdtscSupported;
        public static readonly bool IsRdtscPSupported;
        static Rdtsc()
        {
            SystemInfo systemInfo;
            GetNativeSystemInfo(out systemInfo);
            if (systemInfo.wProcessorArchitecture != 0 /* PROCESSOR_ARCHITECTURE_INTEL */ && 
                systemInfo.wProcessorArchitecture != 9 /* PROCESSOR_ARCHITECTURE_AMD64 */)
            {
                // Fallback for ARM/IA64/...
                Timestamp = StopwatchGetTimestamp;
                TimestampP = StopwatchGetTimestamp;
                IsRdtscSupported = false;
                IsRdtscPSupported = false;
                return;
            }
            byte[] cpuid, rdtsc, rdtscp, rdtsccpuid;
            IsRdtscSupported = true;
            // Assembly generated with https://defuse.ca/online-x86-assembler.htm
            if (Environment.Is64BitProcess)
            {
                /* CPUID x64:
                        push rbx;
                        mov eax, 0x80000000;
                        cpuid;
                        mov ebx, 0x80000001;
                        cmp eax, ebx;
                        jb Error;
                        mov eax, ebx;
                        cpuid;
                        mov eax, ecx;
                        shl rax, 0x20;
                        or rax, rdx
                        jmp End;
                    Error:
                        xor rax, rax;
                    End:
                        pop rbx;
                        ret;
                    0:  53                      push   rbx
                    1:  b8 00 00 00 80          mov    eax,0x80000000
                    6:  0f a2                   cpuid
                    8:  bb 01 00 00 80          mov    ebx,0x80000001
                    d:  39 d8                   cmp    eax,ebx
                    f:  72 0f                   jb     20 <Error>
                    11: 89 d8                   mov    eax,ebx
                    13: 0f a2                   cpuid
                    15: 89 c8                   mov    eax,ecx
                    17: 48 c1 e0 20             shl    rax,0x20
                    1b: 48 09 d0                or     rax,rdx
                    1e: eb 03                   jmp    23 <End>
                    0000000000000020 <Error>:
                    20: 48 31 c0                xor    rax,rax
                    0000000000000023 <End>:
                    23: 5b                      pop    rbx
                    24: c3                      ret
                 */
                cpuid = new byte[] { 0x53, 0xB8, 0x00, 0x00, 0x00, 0x80, 0x0F, 0xA2, 0xBB, 0x01, 0x00, 0x00, 0x80, 0x39, 0xD8, 0x72, 0x16, 0x89, 0xD8, 0x48, 0xC7, 0xC2, 0xFF, 0xFF, 0xFF, 0xFF, 0x0F, 0xA2, 0x89, 0xC8, 0x48, 0xC1, 0xE0, 0x20, 0x48, 0x09, 0xD0, 0xEB, 0x03, 0x48, 0x31, 0xC0, 0x5B, 0xC3 };
                /* RDTSC x64:
                    rdtsc;
                    shl rdx, 0x20;
                    or rax,rdx;
                    ret;
                    0:  0f 31                   rdtsc
                    2:  48 c1 e2 20             shl    rdx,0x20
                    6:  48 09 d0                or     rax,rdx
                    9:  c3                      ret
                 */
                rdtsc = new byte[] { 0x0F, 0x31, 0x48, 0xC1, 0xE2, 0x20, 0x48, 0x09, 0xD0, 0xC3 };
                /* RDTSCP x64
                    rdtscp;
                    shl rdx, 0x20;
                    or rax, rdx;
                    ret;
                    0:  0f 01 f9                rdtscp
                    3:  48 c1 e2 20             shl    rdx,0x20
                    7:  48 09 d0                or     rax,rdx
                    a:  c3                      ret
                 */
                rdtscp = new byte[] { 0x0F, 0x01, 0xF9, 0x48, 0xC1, 0xE2, 0x20, 0x48, 0x09, 0xD0, 0xC3 };
                /* RDTSC + CPUID x64
                    push rbx;
                    xor eax, eax;
                    cpuid;
                    rdtsc;
                    shl rdx, 0x20;
                    or rax, rdx;
                    pop rbx;
                    ret;
                    0:  53                      push   rbx
                    1:  31 c0                   xor    eax,eax
                    3:  0f a2                   cpuid
                    5:  0f 31                   rdtsc
                    7:  48 c1 e2 20             shl    rdx,0x20
                    b:  48 09 d0                or     rax,rdx
                    e:  5b                      pop    rbx
                    f:  c3                      ret
                 */
                rdtsccpuid = new byte[] { 0x53, 0x31, 0xC0, 0x0F, 0xA2, 0x0F, 0x31, 0x48, 0xC1, 0xE2, 0x20, 0x48, 0x09, 0xD0, 0x5B, 0xC3 };
            }
            else
            {
                /* CPUID x86:
                        push ebx;
                        mov eax, 0x80000000;
                        cpuid;
                        mov ebx, 0x80000001;
                        cmp eax, ebx;
                        jb Error;
                        mov eax, ebx;
                        cpuid;
                        mov eax, edx;
                        mov edx, ecx;
                        jmp End;
                    Error:
                        xor eax, eax;
                        xor edx, edx;
                    End:
                        pop ebx;
                        ret;
                    0:  53                      push   ebx
                    1:  b8 00 00 00 80          mov    eax,0x80000000
                    6:  0f a2                   cpuid
                    8:  bb 01 00 00 80          mov    ebx,0x80000001
                    d:  39 d8                   cmp    eax,ebx
                    f:  72 0a                   jb     1b <Error>
                    11: 89 d8                   mov    eax,ebx
                    13: 0f a2                   cpuid
                    15: 89 d0                   mov    eax,edx
                    17: 89 ca                   mov    edx,ecx
                    19: eb 04                   jmp    1f <End>
                    0000001b <Error>:
                    1b: 31 c0                   xor    eax,eax
                    1d: 31 d2                   xor    edx,edx
                    0000001f <End>:
                    1f: 5b                      pop    ebx
                    20: c3                      ret
                */
                cpuid = new byte[] { 0x53, 0xB8, 0x00, 0x00, 0x00, 0x80, 0x0F, 0xA2, 0xBB, 0x01, 0x00, 0x00, 0x80, 0x39, 0xD8, 0x72, 0x0A, 0x89, 0xD8, 0x0F, 0xA2, 0x89, 0xD0, 0x89, 0xCA, 0xEB, 0x04, 0x31, 0xC0, 0x31, 0xD2, 0x5B, 0xC3 };
                /* RDTSC x86:
                    rdtsc;
                    ret;
                    0:  0f 31                   rdtsc
                    2:  c3                      ret
                 */
                rdtsc = new byte[] { 0x0F, 0x31, 0xC3 };
                /* RDTSCP x86
                    rdtscp;
                    ret;
                    0:  0f 01 f9                rdtscp
                    3:  c3                      ret
                 */
                rdtscp = new byte[] { 0x0F, 0x01, 0xF9, 0xC3 };
                /* RDTSC + CPUID x86
                    push ebx;
                    xor eax,eax;
                    cpuid;
                    rdtsc;
                    pop ebx;
                    ret;
                    0:  53                      push   ebx
                    1:  31 c0                   xor    eax,eax
                    3:  0f a2                   cpuid
                    5:  0f 31                   rdtsc
                    7:  5b                      pop    ebx
                    8:  c3                      ret
                 */
                rdtsccpuid = new byte[] { 0x53, 0x31, 0xC0, 0x0F, 0xA2, 0x0F, 0x31, 0x5B, 0xC3 };
            }
            IntPtr buf = IntPtr.Zero;
            try
            {
                // We pad the functions to 64 bytes (the length of a cache
                // line on the Intel processors)
                int cpuidLength = (cpuid.Length & 63) != 0 ? (cpuid.Length | 63) + 1 : cpuid.Length;
                int rdtscLength = (rdtsc.Length & 63) != 0 ? (rdtsc.Length | 63) + 1 : rdtsc.Length;
                int rdtscpLength = (rdtscp.Length & 63) != 0 ? (rdtscp.Length | 63) + 1 : rdtscp.Length;
                int rdtsccpuidLength = (rdtsccpuid.Length & 63) != 0 ? (rdtsccpuid.Length | 63) + 1 : rdtsccpuid.Length;
                // We don't know which one of rdtscp or rdtsccpuid we will
                // use, so we calculate space for the biggest one.
                // Note that it is very unlikely that we will go over 4096
                // bytes (the minimum size of memory allocated by 
                // VirtualAlloc)
                int totalLength = cpuidLength + rdtscLength + Math.Max(rdtscpLength, rdtsccpuidLength);
                // We VirtualAlloc totalLength bytes, with R/W access
                // Note that from what I've read, MEM_RESERVE is useless
                // if the first parameter is IntPtr.Zero
                buf = VirtualAlloc(IntPtr.Zero, (IntPtr)totalLength, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
                if (buf == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
                // Copy cpuid instructions in the buf
                Marshal.Copy(cpuid, 0, buf, cpuid.Length);
                for (int i = cpuid.Length; i < cpuidLength; i++)
                {
                    Marshal.WriteByte(buf, i, 0x90); // nop
                }
                // Copy rdtsc instructions in the buf
                Marshal.Copy(rdtsc, 0, buf + cpuidLength, rdtsc.Length);
                for (int i = rdtsc.Length; i < rdtscLength; i++)
                {
                    Marshal.WriteByte(buf, cpuidLength + i, 0x90); // nop
                }
                var cpuidFunc = (FuncUInt64)Marshal.GetDelegateForFunctionPointer(buf, typeof(FuncUInt64));
                // We use cpuid, EAX=0x80000001 to check for the rdtscp
                ulong supportedFeatures = cpuidFunc();
                byte[] rdtscpSelected;
                int rdtscpSelectedLength;
                // Check the rdtscp flag
                if ((supportedFeatures & (1L << 27)) != 0)
                {
                    // rdtscp supported
                    rdtscpSelected = rdtscp;
                    rdtscpSelectedLength = rdtscpLength;
                    IsRdtscPSupported = true;
                }
                else
                {
                    // rdtscp not supported. We use cpuid + rdtsc
                    rdtscpSelected = rdtsccpuid;
                    rdtscpSelectedLength = rdtsccpuidLength;
                    IsRdtscPSupported = false;
                }
                // Copy rdtscp/rdtsccpuid instructions in the buf
                Marshal.Copy(rdtscpSelected, 0, buf + cpuidLength + rdtscLength, rdtscpSelected.Length);
                for (int i = rdtscpSelected.Length; i < rdtscpSelectedLength; i++)
                {
                    Marshal.WriteByte(buf, cpuidLength + rdtscLength + i, 0x90); // nop
                }
                // Change the access of the allocated memory from R/W to Execute
                uint oldProtection;
                bool result = VirtualProtect(buf, (IntPtr)totalLength, PAGE_EXECUTE, out oldProtection);
                if (!result)
                {
                    throw new Win32Exception();
                }
                // Create a delegate to the "function"
                Timestamp = (FuncUInt64)Marshal.GetDelegateForFunctionPointer(buf + cpuidLength, typeof(FuncUInt64));
                TimestampP = (FuncUInt64)Marshal.GetDelegateForFunctionPointer(buf + cpuidLength + rdtscLength, typeof(FuncUInt64));
                buf = IntPtr.Zero;
            }
            finally
            {
                // There was an error!
                if (buf != IntPtr.Zero)
                {
                    // Free the allocated memory
                    bool result = VirtualFree(buf, IntPtr.Zero, MEM_RELEASE);
                    if (!result)
                    {
                        throw new Win32Exception();
                    }
                }
            }
        }
        // Fallback if rdtsc isn't available. We can't use directly
        // Stopwatch.GetTimestamp() because the return type is different.
        private static ulong StopwatchGetTimestamp()
        {
            return unchecked((ulong)Stopwatch.GetTimestamp());
        }
    }
