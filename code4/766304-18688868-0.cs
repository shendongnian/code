        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                // Some code that might set e.Cancel = true
                //...
            }
            base.OnFormClosing(e);
        }
