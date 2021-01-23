        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                Files.SelectedIndex = File.SelectedIndex + 1;
            }
        }
        private void Files_SelectedIndexChanged(object sender, EventArgs e)
        {
            playNewFile = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (playNewFile)
            {
                axWindowsMediaPlayer1.URL = percorsi[Files.SelectedIndex];
                playNewFile = false;
            }
        }
