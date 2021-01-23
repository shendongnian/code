    using System;
    using System.Windows.Forms;
    
    class D2D1RenderTarget : Control {
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            if (!this.DesignMode) {
                this.SetStyle(ControlStyles.UserPaint, false);
                // Initialize D2D1 here, use this.Handle
                //...
            }
        }
    }
