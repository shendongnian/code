    class ControlMover {
        private Control control;
        private Point downPos;
        private Point startPos;
        enum Constrains { None, Hor, Ver };
        private Constrains constraint;
        public ControlMover(Control ctl) {
            control = ctl;
            startPos = control.Location;
            downPos = Cursor.Position;
            control.Capture = true;
            control.MouseMove += control_MouseMove;
            control.MouseUp += control_MouseUp;
            control.MouseCaptureChanged += control_MouseCaptureChanged;
            control.KeyDown += control_KeyDown;
            control.KeyUp += control_KeyUp;
        }
        void handleKey(Keys key, bool down) {
            Console.WriteLine((int)key);
            if (key == Keys.Escape) {
                control.Capture = false;
                control.Location = startPos;
            }
            else if ((key & Keys.KeyCode) == Keys.ShiftKey) {
                if (!down) constraint = Constrains.None;
                else if (constraint == Constrains.None) {
                    var curPos = Cursor.Position;
                    if (Math.Abs(curPos.X - downPos.X) >= Math.Abs(curPos.Y - downPos.Y))
                         constraint = Constrains.Hor;
                    else constraint = Constrains.Ver;
                }
                moveControl();
            }
        }
        void control_MouseCaptureChanged(object sender, EventArgs e) {
            // This ends it
            if (control.Capture) return;
            control.MouseMove -= control_MouseMove;
            control.MouseUp -= control_MouseUp;
            control.MouseCaptureChanged -= control_MouseCaptureChanged;
            control.KeyDown -= control_KeyDown;
            control.KeyUp -= control_KeyUp;
        }
        private void moveControl() {
            var curPos = Cursor.Position;
            if (constraint == Constrains.Hor) curPos.Y = downPos.Y;
            if (constraint == Constrains.Ver) curPos.X = downPos.X;
            curPos = control.Parent.PointToClient(curPos);
            // Keep it inside the parent
            curPos.X = Math.Max(0, curPos.X);
            curPos.Y = Math.Max(0, curPos.Y);
            curPos.X = Math.Min(control.Parent.ClientSize.Width - control.Width, curPos.X);
            curPos.Y = Math.Min(control.Parent.ClientSize.Height - control.Height, curPos.Y);
            control.Location = curPos;
        }
        void control_MouseUp(object sender, MouseEventArgs e) { control.Capture = false; }
        void control_MouseMove(object sender, MouseEventArgs e) { moveControl(); }
        void control_KeyDown(object sender, KeyEventArgs e) { handleKey(e.KeyData, true); }
        void control_KeyUp(object sender, KeyEventArgs e) { handleKey(e.KeyData, false); }
    }
