    using System;
    using System.Windows.Forms;
    
    class SvgWrapper : Control {
        public SvgWrapper() {
            this.SetStyle(ControlStyles.UserPaint, false);
            this.SetStyle(ControlStyles.UserMouse, false);
        }
        protected override CreateParams CreateParams {
            get {
                // Todo: ensure the native DLL is loaded
                //...
                var cp = base.CreateParams;
                if (!this.DesignMode) {
                    cp.ClassName = "SVGCoreClassName";
                }
                return cp;
            }
        }
        protected override void OnHandleCreated(EventArgs e) {
            // Substitute for "this" argument to CreateWindow
            //...
            base.OnHandleCreated(e);
        }
    }
