        private bool mayClose = false;
        public void PerformClose()
        {
            this.mayClose = true;
            this.Close();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.mayClose)
                e.Cancel = true;
        }
