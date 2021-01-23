        using System.Runtime.InteropServices;
        public class ShellItems
        {
            [StructLayoutAttribute(LayoutKind.Sequential)]
            private struct LVITEM
            {
                public uint mask;
                public int iItem;
                public int iSubItem;
                public uint state;
                public uint stateMask;
                public IntPtr pszText;
                public int cchTextMax;
                public int iImage;
                public IntPtr lParam;
            }
    
            const int LVM_FIRST = 0x1000;
            const int LVM_GETSELECTEDCOUNT = 4146;
            const int LVM_GETNEXTITEM = LVM_FIRST + 12;
            const int LVNI_SELECTED = 2;
            const int LVM_GETITEMCOUNT = LVM_FIRST + 4;
            const int LVM_GETITEM = LVM_FIRST + 75;
            const int LVIF_TEXT = 0x0001;
    
            [DllImport("user32.dll", EntryPoint = "GetShellWindow")]
            public static extern System.IntPtr GetShellWindow();
    
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
    
            [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
            public static extern int SendMessagePtr(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    
            [DllImport("User32.DLL")]
            public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
    
    
            public int SelectedItemCount
            {
                get
                {
                    return SendMessage(ShellListViewHandle, LVM_GETSELECTEDCOUNT, IntPtr.Zero.ToInt32(), IntPtr.Zero.ToInt32());
                }
            }
            public int Count
            {
                get
                {
                    return SendMessage(ShellListViewHandle, LVM_GETITEMCOUNT, IntPtr.Zero.ToInt32(), IntPtr.Zero.ToInt32());
                }
            }
            public string GetItemText(int idx)
            {
                // Declare and populate the LVITEM structure
                LVITEM lvi = new LVITEM();
                lvi.mask = LVIF_TEXT;
                lvi.cchTextMax = 512;
                lvi.iItem = idx;            // the zero-based index of the ListView item
                lvi.iSubItem = 0;         // the one-based index of the subitem, or 0 if this
                //  structure refers to an item rather than a subitem
                lvi.pszText = Marshal.AllocHGlobal(512);
    
                // Send the LVM_GETITEM message to fill the LVITEM structure
                IntPtr ptrLvi = Marshal.AllocHGlobal(Marshal.SizeOf(lvi));
                Marshal.StructureToPtr(lvi, ptrLvi, false);
                try
                {
                    SendMessagePtr(ShellListViewHandle, LVM_GETITEM, IntPtr.Zero, ptrLvi);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
    
                // Extract the text of the specified item
                string itemText = Marshal.PtrToStringAuto(lvi.pszText);
                return itemText;
            }
    
            IntPtr ShellListViewHandle
            {
                get
                {
                    IntPtr _ProgMan = GetShellWindow();
                    IntPtr _SHELLDLL_DefViewParent = _ProgMan;
                    IntPtr _SHELLDLL_DefView = FindWindowEx(_ProgMan, IntPtr.Zero, "SHELLDLL_DefView", null);
                    IntPtr _SysListView32 = FindWindowEx(_SHELLDLL_DefView, IntPtr.Zero, "SysListView32", "FolderView");
                    return _SysListView32;
                }
            }
    
            public int GetSelectedItemIndex(int iPos = -1)
            {
                return SendMessage(ShellListViewHandle, LVM_GETNEXTITEM, iPos, LVNI_SELECTED);
            }
        }
