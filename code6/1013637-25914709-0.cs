    public static class TextBoxBaseExtensions
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, int wParam, Int32 lParam);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 0x000B;
        private const int WM_VSCROLL = 0x0115;
        private const int SB_BOTTOM = 0x0007;
        private const int SB_TOP = 0x0006;
        public static void ScrollToBottom(this TextBoxBase iTextBoxBase)
        {
            SendMessage(iTextBoxBase.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }
        public static void ScrollToTop(this TextBoxBase iTextBoxBase)
        {
            SendMessage(iTextBoxBase.Handle, WM_VSCROLL, SB_TOP, 0);
        }
        public static void SetRedraw(this TextBoxBase iTextBoxBase, bool iBool)
        {
            SendMessage(iTextBoxBase.Handle, WM_SETREDRAW, iBool, 0);
        }
    }
