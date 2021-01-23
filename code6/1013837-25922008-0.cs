    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public int flags;
    }
    public partial class Form1 : Form
    {
        private const int SnapOffset = 35;
        private const int WM_WINDOWPOSCHANGING = 70;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_WINDOWPOSCHANGING)
            {
                SnapToDesktopBorder(this, m.LParam, 0);
            }
            
            base.WndProc(ref m);
        }
        private void SnapToDesktopBorder(Form clientForm, IntPtr intPtr, int widthAdjustment)
        {
            var newPosition = new WINDOWPOS();
            newPosition = (WINDOWPOS)System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(WINDOWPOS));
            if (newPosition.y == 0 || newPosition.x == 0)
            {
                return;
                // Nothing to do!
            }
            // Adjust the client size for borders and caption bar
            Rectangle ClientRect = clientForm.RectangleToScreen(clientForm.ClientRectangle);
            ClientRect.Width += SystemInformation.FrameBorderSize.Width - widthAdjustment;
            ClientRect.Height += (SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight);
            // Now get the screen working area (without taskbar)
            Rectangle WorkingRect = Screen.FromControl(clientForm).WorkingArea;
            // Left border
            if (newPosition.x >= WorkingRect.X - SnapOffset && newPosition.x <= WorkingRect.X + SnapOffset)
            {
                newPosition.x = WorkingRect.X;
            }
            // Get screen bounds and taskbar height
            // (when taskbar is horizontal)
            Rectangle ScreenRect = Screen.FromControl(clientForm).Bounds;
            int TaskbarHeight = ScreenRect.Height - WorkingRect.Height;
            // Top border (check if taskbar is on top
            // or bottom via WorkingRect.Y)
            if (newPosition.y >= -SnapOffset && (WorkingRect.Y > 0 && newPosition.y <= (TaskbarHeight + SnapOffset)) || (WorkingRect.Y <= 0 && newPosition.y <= (SnapOffset)))
            {
                if (TaskbarHeight > 0)
                {
                    newPosition.y = WorkingRect.Y;
                    // Horizontal Taskbar
                }
                else
                {
                    newPosition.y = 0;
                    // Vertical Taskbar
                }
            }
            // Right border
            if (newPosition.x + ClientRect.Width <= WorkingRect.Right + SnapOffset && newPosition.x + ClientRect.Width >= WorkingRect.Right - SnapOffset)
            {
                newPosition.x = WorkingRect.Right - (ClientRect.Width + SystemInformation.FrameBorderSize.Width);
            }
            // Bottom border
            if (newPosition.y + ClientRect.Height <= WorkingRect.Bottom + SnapOffset && newPosition.y + ClientRect.Height >= WorkingRect.Bottom - SnapOffset)
            {
                newPosition.y = WorkingRect.Bottom - (ClientRect.Height + SystemInformation.FrameBorderSize.Height);
            }
            // Marshal it back
            System.Runtime.InteropServices.Marshal.StructureToPtr(newPosition, intPtr, true);
        }
    }
