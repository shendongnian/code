    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct MENUITEMINFO
        {
            public uint cbSize;
            public uint fMask;
            public uint fType;
            public uint fState;
            public uint wID;
            public IntPtr hSubMenu;
            public IntPtr hbmpChecked;
            public IntPtr hbmpUnchecked;
            public IntPtr dwItemData;
            public string dwTypeData;
            public uint cch;
            public IntPtr hbmpItem;
            // return the size of the structure
            public static uint sizeOf
            {
                get { return (uint)Marshal.SizeOf(typeof(MENUITEMINFO)); }
            }
        }
            IntPtr hWnd = FindWindow(null, "untitled - notepad");
            IntPtr hMenu = GetMenu(hWnd);
            MENUITEMINFO mif = new MENUITEMINFO();
            uint MIIM_STRING = 0x00000040;
            uint MFT_STRING = 0x00000000;
            mif.cbSize = MENUITEMINFO.sizeOf;//(uint)Marshal.SizeOf(typeof(MENUITEMINFO));
            mif.fMask = MIIM_STRING;
            mif.fType = MFT_STRING;
            mif.dwTypeData = null;
            //IntPtr hMenu = menuStrip1.Handle;
            //1st call to get the text length into (cch)
            bool res = GetMenuItemInfo(hMenu, (uint)0, true, ref mif); //To load cch into memory
            if (res)
            {
                mif.cch += 1;
                //Set the length of the buffer to cch + 1
                mif.dwTypeData = new string(' ', (int)(mif.cch));
                res = GetMenuItemInfo(hMenu, (uint)0, true, ref mif); //To fill dwTypeData
            }
