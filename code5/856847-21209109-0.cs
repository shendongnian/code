    IKnownFolder folder = KnownFolders.RecycleBin;
    foreach (ShellObject deleted in folder)
    {
        if (...) // whatever
        {
            CallShellItemVerb(deleted.Properties.System.ParsingPath.Value, "undelete");
        }
    }
    
    public static void CallShellItemVerb(string parsingPath, string verb)
    {
        if (parsingPath == null)
            throw new ArgumentNullException("parsingPath");
    
        if (verb == null)
        {
            verb = "open";
        }
    
        // get an item from the path
        IShellItem item;
        int hr = SHCreateItemFromParsingName(parsingPath, IntPtr.Zero, typeof(IShellItem).GUID, out item);
        if (hr < 0)
            throw new Win32Exception(hr);
    
        // get the context menu from the item
        IContextMenu menu;
        Guid BHID_SFUIObject = new Guid("{3981e225-f559-11d3-8e3a-00c04f6837d5}");
        hr = item.BindToHandler(IntPtr.Zero, BHID_SFUIObject, typeof(IContextMenu).GUID, out menu);
        if (hr < 0)
            throw new Win32Exception(hr);
    
        // build a fake context menu so we can scan it for the verb's menu id
        ContextMenu cm = new ContextMenu();
        hr = menu.QueryContextMenu(cm.Handle, 0, 0, -1, CMF_NORMAL);
        if (hr < 0)
            throw new Win32Exception(hr);
    
        int count = GetMenuItemCount(cm.Handle);
        int verbId = -1;
        for (int i = 0; i < count; i++)
        {
            int id = GetMenuItemID(cm.Handle, i);
            if (id < 0)
                continue;
    
            StringBuilder sb = new StringBuilder(256);
            hr = menu.GetCommandString(id, GCS_VERBW, IntPtr.Zero, sb, sb.Capacity);
            if (sb.ToString() == verb)
            {
                verbId = id;
                break;
            }
        }
    
        if (verbId < 0)
            throw new Win32Exception("Verb '" + verb + "' is not supported by the item");
    
        // call that verb
        CMINVOKECOMMANDINFO ci = new CMINVOKECOMMANDINFO();
        ci.cbSize = Marshal.SizeOf(typeof(CMINVOKECOMMANDINFO));
        ci.lpVerb  = (IntPtr)verbId;
        hr = menu.InvokeCommand(ref ci);
        if (hr < 0)
            throw new Win32Exception(hr);
    }
    
    [ComImport, Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IShellItem
    {
        // NOTE: only partially defined, don't use in other contexts
        [PreserveSig]
        int BindToHandler(IntPtr pbc, [MarshalAs(UnmanagedType.LPStruct)] Guid bhid, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IContextMenu ppv);
    }
    
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214e4-0000-0000-c000-000000000046")]
    private interface IContextMenu
    {
        [PreserveSig]
        int QueryContextMenu(IntPtr hmenu, int iMenu, int idCmdFirst, int idCmdLast, int uFlags); 
    
        [PreserveSig]
        int InvokeCommand(ref CMINVOKECOMMANDINFO pici);
    
        [PreserveSig]
        int GetCommandString(int idCmd, int uFlags, IntPtr pwReserved, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMax);
    }
    
    [DllImport("user32.dll")]
    private static extern int GetMenuItemCount(IntPtr hMenu);
    
    [DllImport("user32.dll")]
    private static extern int GetMenuItemID(IntPtr hMenu, int nPos);
    
    [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern int SHCreateItemFromParsingName(string path, IntPtr pbc, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IShellItem item);
    
    private const int CMF_NORMAL = 0x00000000;
    private const int GCS_VERBW = 4;
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct CMINVOKECOMMANDINFO
    {
        public int cbSize;
        public int fMask;
        public IntPtr hwnd;
        public IntPtr lpVerb;
        public string lpParameters;
        public string lpDirectory;
        public int nShow;
        public int dwHotKey;
        public IntPtr hIcon;
    }
