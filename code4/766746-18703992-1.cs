        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LockControls(true);
            Login();
            this.Cursor = Cursors.Default;
            LockControls(false);
        }
        private void LockControls(bool mylock)
        {
            this.Enabled = !mylock;
        }
        private void Login()
        {
            Thread.Sleep(5 * 1000);     
        }
