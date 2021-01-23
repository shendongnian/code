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
            const int LVM_GETITEMCOUNT = 4100;
            const int LVM_GETNEXTITEM = LVM_FIRST + 12;
            const int LVNI_SELECTED = 2;
     
     
            [DllImport("user32.dll", EntryPoint = "GetShellWindow")]
            public static extern System.IntPtr GetShellWindow();
     
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
     
            //[DllImport("user32.dll")]
            //public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
     
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
     
            public int GetItemIndex(int iPos = -1)
            {
                return SendMessage(ShellListViewHandle, LVM_GETNEXTITEM, iPos, LVNI_SELECTED);
            }
        }
