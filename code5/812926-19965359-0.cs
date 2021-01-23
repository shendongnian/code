    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class Magnifier : Control {
        public Magnifier() {
            if (!MagInitialize()) throw new NotSupportedException();
            timer = new Timer { Interval = 45 };
            timer.Tick += (o, ea) => { if (trackMouse) setSource(false); else Invalidate(); };
        }
        [DefaultValue(false)]
        public bool TrackMouse {
            get { return trackMouse; }
            set { trackMouse = value; setSource(false); }
        }
        [DefaultValue(2.0f)]
        public float Magnification {
            get { return magnification; }
            set { magnification = Math.Max(1, value); setSource(true); }
        }
    
        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                if (!this.DesignMode) {
                    cp.ClassName = "Magnifier";
                    //cp.Style |= MS_SHOWMAGNIFIEDCURSOR;
                    this.SetStyle(ControlStyles.UserPaint, true);
                }
                return cp;
            }
        }
    
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            if (!this.DesignMode) {
                setSource(true);
                this.FindForm().LocationChanged += ParentLocationChanged;
                timer.Start();
            }
        }
        protected override void Dispose(bool disposing) {
            if (disposing) {
                var frm = this.FindForm();
                if (frm != null) frm.LocationChanged -= ParentLocationChanged;
                timer.Dispose();
                MagUninitialize();
            }
            base.Dispose(disposing);
        }
    
        private void ParentLocationChanged(object sender, EventArgs e) {
            if (!trackMouse) setSource(false);
        }
        protected override void OnSizeChanged(EventArgs e) {
            setSource(false);
            base.OnSizeChanged(e);
        }
        protected override void OnMouseWheel(MouseEventArgs e) {
            this.Magnification += e.Delta / 100f;
            ((HandledMouseEventArgs)e).Handled = true;
        }
    
        private void setSource(bool newmag) {
            if (!this.IsHandleCreated || this.DesignMode) return;
            if (newmag) {
                var xform = new MAGTRANSFORM();
                xform.v11 = xform.v22 = magnification;
                xform.v33 = 1.0f;
                MagSetWindowTransform(this.Handle, ref xform);
            }
            Point center;
            if (trackMouse) center = Cursor.Position;
            else {
                var rc = this.RectangleToScreen(this.Bounds);
                center = new Point(rc.Left + rc.Width / 2, rc.Top + rc.Height / 2);
            }
            var scr = Screen.FromPoint(center);
            var rect = new RECT();
            rect.left = Math.Max(scr.Bounds.Left, center.X - (int)(this.Width / magnification / 2));
            rect.top = Math.Max(scr.Bounds.Top, center.Y - (int)(this.Height / magnification / 2));
            rect.right = rect.left + (int)(this.Width / magnification);
            if (rect.right > scr.Bounds.Right) {
                rect.right = scr.Bounds.Right;
                rect.left = rect.right - (int)(this.Width / magnification);
            }
            rect.bottom = center.Y + (int)(this.Height / magnification);
            if (rect.bottom > scr.Bounds.Bottom) {
                rect.bottom = scr.Bounds.Bottom;
                rect.top = rect.bottom - (int)(this.Height / magnification);
            }
            MagSetWindowSource(this.Handle, ref rect);
            this.Invalidate();
        }
    
        private Timer timer;
        private bool trackMouse;
        private float magnification = 2.0f;
    
        private struct RECT {
            public int left, top, right, bottom;
        }
        private struct MAGTRANSFORM {
            public float v11, v12, v13;
            public float v21, v22, v23;
            public float v31, v32, v33;
        }
        [DllImport("magnification.dll")]
        private static extern bool MagInitialize();
        [DllImport("magnification.dll")]
        private static extern bool MagUninitialize();
        [DllImport("magnification.dll")]
        private static extern bool MagSetWindowSource(IntPtr hWnd, ref RECT rc);
        [DllImport("magnification.dll")]
        private static extern bool MagSetWindowTransform(IntPtr hWnd, ref MAGTRANSFORM xform);
        private const int MS_SHOWMAGNIFIEDCURSOR = 1;
        private const int MS_CLIPAROUNDCURSOR = 2;
        private const int MS_INVERTCOLORS = 4;
    }
