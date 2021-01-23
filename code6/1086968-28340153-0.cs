    class MyDataGridView : DataGridView
    {
        protected override void WndProc(ref Message m)
        {
            // If the message is for this component, is about mouse wheel
            // and if the shift key is pressed,
            // we transmit it to the parent control.
            // Otherwise, we handle it normally.
            if ((m.HWnd == Handle) && (m.Msg == WM_MOUSEWHEEL) && (ModifierKeys == Keys.Shift))
            {
                PostMessage(Parent.Handle, m.Msg, m.WParam, m.LParam);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        #region User32.dll
        [DllImport("User32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private const int WM_MOUSEWHEEL = 0x020A;
        #endregion
    }
