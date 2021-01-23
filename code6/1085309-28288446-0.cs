    public class ScrollableListView : ListView
    {
        private const int WM_VSCROLL = 0x115;
        private enum ScrollBar : int { Horizontal = 0x0, Vertical = 0x1 }
        public void SetScroll(int x, int y)
        {
            this.SetScroll(ScrollBar.Horizontal, x);
            this.SetScroll(ScrollBar.Vertical, y);
        }
        public void SetScrollX(int position)
        {
            this.SetScroll(ScrollBar.Horizontal, position);
        }
        public void SetScrollY(int position)
        {
            this.SetScroll(ScrollBar.Vertical, position);
        }
        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        private void SetScroll(ScrollBar bar, int position)
        {
            if (!this.IsDisposed)
            {
                ScrollableListView.SetScrollPos((IntPtr)this.Handle, (int)bar, position, true);
                ScrollableListView.PostMessage((IntPtr)this.Handle, ScrollableListView.WM_VSCROLL, 4 + 0x10000 * position, 0);
            }
        }
    }
