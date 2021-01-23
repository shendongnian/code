        private Point TabMouseDownPos;
        private void tabControl1_MouseDown(object sender, MouseEventArgs e) {
            TabMouseDownPos = e.Location;
        }
        private void tabControl1_MouseMove(object sender, MouseEventArgs e) {
            // Detect start of drag
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
            int dx = e.X - TabMouseDownPos.X;
            int dy = e.Y - TabMouseDownPos.Y;
            if (Math.Abs(dx) >= SystemInformation.DoubleClickSize.Width ||
                Math.Abs(dy) >= SystemInformation.DoubleClickSize.Height) {
                // Start drag, create the form at the same position as the tab
                Form form = CreateTabForm();
                form.StartPosition = FormStartPosition.Manual;
                var tabpos = tabControl1.GetTabRect(tabControl1.SelectedIndex);
                form.Location = tabControl1.PointToScreen(new Point(tabpos.Left + dx, tabpos.Top + dy));
                // Juggle the mouse so it now starts dragging the form
                tabControl1.Capture = false;
                PostMessage(form.Handle, WM_NCLBUTTONDOWN, (IntPtr)2, IntPtr.Zero);
                form.ShowDialog();          
            }
        }
        private Form CreateTabForm() {
            // Return form object that matches tabControl1.SelectedIndex
            //...
            return new Form2();
        }
        private const int WM_NCLBUTTONDOWN = 0x00a1;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
