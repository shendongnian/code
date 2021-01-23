        private System.Windows.Forms.Timer tmr;
        private void timerCallBack(object sender, EventArgs e)
        {
        }
        private void createTimer()
        {
            tmr = new System.Windows.Forms.Timer(this.components);
            tmr.Tick += new System.EventHandler(this.timerCallBack);
        }
