        public void SetWaitCursor(bool b_Wait)
        {
            Application.UseWaitCursor = b_Wait;
            // The Browser control must be disabled otherwise it does not show the wait cursor.
            webBrowser.Enabled = !b_Wait;
            Application.DoEvents();
        }
