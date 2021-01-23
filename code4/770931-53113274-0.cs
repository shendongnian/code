    protected override void OnResizeBegin(EventArgs e) {
                SuspendLayout();
                base.OnResizeBegin(e);
            }
            protected override void OnResizeEnd(EventArgs e) {
                ResumeLayout();
                base.OnResizeEnd(e);
            }
