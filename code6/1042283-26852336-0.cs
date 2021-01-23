        [DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hWnd, bool enable);
        protected override void OnVisibleChanged(EventArg e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                EnableWindow(this.Handle, true);
            }
        }
