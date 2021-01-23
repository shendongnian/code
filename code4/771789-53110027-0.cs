            [SuppressUnmanagedCodeSecurity]
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            private delegate int AssemblyAddFunction(int x, int y);
            [DllImport("kernel32.dll")]
            private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);
            ....................................
            byte[] assembledCode =
            {
                0x55,               // 0 push ebp            
                0x8B, 0x45, 0x08,   // 1 mov  eax, [ebp+8]   
                0x8B, 0x55, 0x0C,   // 4 mov  edx, [ebp+12]  
                0x01, 0xD0,         // 7 add  eax, edx       
                0x5D,               // 9 pop  ebp            
                0xC3                // A ret                 
            };
            int returnValue;
            unsafe
            {
                fixed (byte* ptr = assembledCode)
                {
                    var memoryAddress = (IntPtr) ptr;
                    // Mark memory as EXECUTE_READWRITE to prevent DEP exceptions
                    if (!VirtualProtectEx(Process.GetCurrentProcess().Handle, memoryAddress,
                        (UIntPtr) assembledCode.Length, 0x40 /* EXECUTE_READWRITE */, out uint _))
                    {
                        throw new Win32Exception();
                    }
                    var myAssemblyFunction = Marshal.GetDelegateForFunctionPointer<AssemblyAddFunction>(memoryAddress);
                    returnValue = myAssemblyFunction(10, -15);
                }               
            }
  
            Console.WriteLine($"Return value: {returnValue}"); // Prints -5
