        bool shouldTerminate;
        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing && !shouldTerminate) {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            base.OnFormClosing(e);
        }
