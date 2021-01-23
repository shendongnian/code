    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool GetMenuItemInfo(IntPtr hMenu, int uItem, bool fByPosition, MENUITEMINFO lpmii);
    
    [StructLayout(LayoutKind.Sequential)]
    public class MENUITEMINFO 
    {
        public int cbSize;
        public uint fMask;
        public uint fType;
        public uint fState;
        public uint wID;
        public IntPtr hSubMenu;
        public IntPtr hbmpChecked;
        public IntPtr hbmpUnchecked;
        public IntPtr dwItemData;
        public IntPtr dwTypeData;
        public uint cch;
        public IntPtr hbmpItem;
        public MENUITEMINFO()
        {
            cbSize = Marshal.SizeOf(typeof(MENUITEMINFO));
        }
    }
    ....
    MENUITEMINFO mif = new MENUITEMINFO();
    // initialize members
    mif.dwTypeData = IntPtr.Zero;
    bool res = GetMenuItemInfo(hMenu, 0, true, mif);
    if (!res)
        throw new Win32Exception();
    mif.dwTypeData = Marshal.AllocHGlobal(mif.cch*sizeof(char));
    try
    {
        bool res = GetMenuItemInfo(hMenu, 0, true, mif);
        if (!res)
            throw new Win32Exception();
        string caption = Marshal.PtrToStringUni(mif.dwTypeData);
    }
    finally
    {
        Marshal.FreeHGlobal(mif.dwTypeData);
    }
