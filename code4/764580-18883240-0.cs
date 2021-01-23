        private System.Windows.Forms.Timer timer;
        
        private void OnPlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 3:
                    if (!timer.Enabled)
                    {
                        this.player.Ctlcontrols.pause();
                        this.timer.Interval = (37 - 5) * 1000; // 37 seconds 
                        this.timer.Start();
                    }
                    break;
            }
        }
        protected override void OnTimerTick(object sender, EventArgs e)
        {
            this.player.Ctlcontrols.play();
            this.timer.Stop();
        }
