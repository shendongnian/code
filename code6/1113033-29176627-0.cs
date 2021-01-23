        public void MaximizeWindow(bool IsFullScreenWithTaskbar)
        {
            if (IsFullScreenWithTaskbar)
            {
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;             
            }
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowState = WindowState.Maximized;
        }
