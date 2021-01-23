    class Program
    {
        static void Main(string[] args)
        {
            var shellWindows = new ShellWindows();
            foreach (IWebBrowser2 win in shellWindows)
            {
                IServiceProvider sp = win as IServiceProvider;
                object sb;
                sp.QueryService(SID_STopLevelBrowser, typeof(IShellBrowser).GUID, out sb);
                IShellBrowser shellBrowser = (IShellBrowser)sb;
                object sv;
                shellBrowser.QueryActiveShellView(out sv);
                Console.WriteLine(win.LocationURL + " " + win.LocationName);
                IFolderView fv = sv as IFolderView;
                if (fv != null)
                {
                    // only folder implementation support this (IE windows do not for example)
                    object pf;
                    fv.GetFolder(typeof(IPersistFolder2).GUID, out pf);
                    IPersistFolder2 persistFolder = (IPersistFolder2)pf;
                    // get folder class, for example
                    // CLSID_ShellFSFolder for standard explorer folders
                    Guid clsid;
                    persistFolder.GetClassID(out clsid);
                    Console.WriteLine(" clsid:" + clsid);
                    // get current folder pidl
                    IntPtr pidl;
                    persistFolder.GetCurFolder(out pidl);
                    // TODO: do something with pidl
                    
                    Marshal.FreeCoTaskMem(pidl); // free pidl's allocated memory
                }
            }
        }
        internal static readonly Guid SID_STopLevelBrowser = new Guid(0x4C96BE40, 0x915C, 0x11CF, 0x99, 0xD3, 0x00, 0xAA, 0x00, 0x4A, 0xE8, 0x37);
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6D5140C1-7436-11CE-8034-00AA006009FA")]
        internal interface IServiceProvider
        {
            void QueryService([MarshalAs(UnmanagedType.LPStruct)] Guid guidService, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObject);
        }
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1AC3D9F0-175C-11d1-95BE-00609797EA4F")]
        internal interface IPersistFolder2
        {
            void GetClassID(out Guid pClassID);
            void Initialize(IntPtr pidl);
            void GetCurFolder(out IntPtr pidl);
        }
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E2-0000-0000-C000-000000000046")]
        internal interface IShellBrowser
        {
            void _VtblGap0_12(); // skip 12 members
            void QueryActiveShellView([MarshalAs(UnmanagedType.IUnknown)] out object ppshv);
            // the rest is not defined
        }
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("cde725b0-ccc9-4519-917e-325d72fab4ce")]
        internal interface IFolderView
        {
            void _VtblGap0_2(); // skip 2 members
            void GetFolder([MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
            // the rest is not defined
        }
    }
