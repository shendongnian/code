            [Flags]
            private enum SHGFI : int
            {
                /// <summary>get type name</summary>
                TypeName = 0x000000400,
            }
    
            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi,
                uint cbFileInfo, uint uFlags);
    
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct SHFILEINFO
            {
                public IntPtr hIcon;
                public int iIcon;
                public uint dwAttributes;
    
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szDisplayName;
    
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string szTypeName;
            };
    
            private static void Main()
            {
                SHGFI flags = SHGFI.TypeName;
                SHFILEINFO shinfo = new SHFILEINFO();
               SHGetFileInfo(your path, 0,
                    ref shinfo, (uint) Marshal.SizeOf(shinfo),(uint) flags);
    
                Console.WriteLine(shinfo.szTypeName);
    
                Console.ReadKey();
            }
