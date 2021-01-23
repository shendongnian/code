    public static class GacUtil
    {
        [DllImport("fusion.dll")]
        private static extern IntPtr CreateAssemblyCache(
            out IAssemblyCache ppAsmCache, 
            int reserved);
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae")]
        private interface IAssemblyCache
        {
            int Dummy1();
            [PreserveSig()]
            IntPtr QueryAssemblyInfo(
                int flags, 
                [MarshalAs(UnmanagedType.LPWStr)] string assemblyName, 
                ref AssemblyInfo assemblyInfo);
            int Dummy2();
            int Dummy3();
            int Dummy4();
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct AssemblyInfo
        {
            public int cbAssemblyInfo;
            public int assemblyFlags;
            public long assemblySizeInKB;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string currentAssemblyPath;
            public int cchBuf;
        }
        public static bool IsAssemblyInGAC(string assemblyName)
        {
            var assembyInfo = new AssemblyInfo { cchBuf = 512 };
            assembyInfo.currentAssemblyPath = new string('\0', assembyInfo.cchBuf);
            IAssemblyCache assemblyCache;
            var hr = CreateAssemblyCache(out assemblyCache, 0);
            if (hr == IntPtr.Zero)
            {
                hr = assemblyCache.QueryAssemblyInfo(
                    1, 
                    assemblyName, 
                    ref assembyInfo);
                if (hr != IntPtr.Zero)
                {
                    return false;
                }
                return true;
            }
            Marshal.ThrowExceptionForHR(hr.ToInt32());
            return false;
        }
    }
