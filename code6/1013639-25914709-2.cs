    public static class TextBoxBaseExtensions
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, int wParam, Int32 lParam);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_VSCROLL = 0x0115;
        private const int SB_LINEUP = 0x00000;
        private const int SB_LINEDOWN = 0x00001;
        private const int SB_BOTTOM = 0x0007;
        private const int SB_TOP = 0x0006;
        public static void ScrollLineUp(this TextBoxBase iTextBoxBase)
        {
            SendMessage(iTextBoxBase.Handle, WM_VSCROLL, SB_LINEUP, 0);
        }
        public static void ScrollLineDown(this TextBoxBase iTextBoxBase)
        {
            SendMessage(iTextBoxBase.Handle, WM_VSCROLL, SB_LINEDOWN, 0);
        }
        public static void ScrollToBottom(this TextBoxBase iTextBoxBase)
        {
            SendMessage(iTextBoxBase.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }
        public static void ScrollToTop(this TextBoxBase iTextBoxBase)
        {
            SendMessage(iTextBoxBase.Handle, WM_VSCROLL, SB_TOP, 0);
        }
    }
