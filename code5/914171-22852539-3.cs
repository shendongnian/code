    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MENUITEMINFO_T
    {
        public int cbSize = Marshal.SizeOf(typeof(NativeMethods.MENUITEMINFO_T));
        public int fMask;
        public int fType;
        public int fState;
        public int wID;
        public IntPtr hSubMenu;
        public IntPtr hbmpChecked;
        public IntPtr hbmpUnchecked;
        public IntPtr dwItemData;
        public string dwTypeData;
        public int cch;
    }
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool GetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, [In, Out] MENUITEMINFO_T lpmii);
      ................
      MENUITEMINFO_T menuiteminfo_t;
      menuiteminfo_t = new MENUITEMINFO_T();
      menuiteminfo_t.fMask = MIIM_STRING;
      menuiteminfo_t.dwTypeData = new string('\0', 256);
      menuiteminfo_t.cch = menuiteminfo_t.dwTypeData.Length - 1;
      bool result = GetMenuItemInfo(new HandleRef(null, hMenu), 0, true, menuiteminfo_t);
