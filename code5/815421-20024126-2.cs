    AxWMPLib.AxWindowsMediaPlayer wmPlayer;
    private void button2_Click(object sender, EventArgs e)
        {
            wmPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            wmPlayer.CreateControl();
            wmPlayer.enableContextMenu = false;
            ((System.ComponentModel.ISupportInitialize)(wmPlayer)).BeginInit();
            wmPlayer.Name = "wmPlayer";
            wmPlayer.Enabled = true;
            wmPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(wmPlayer);
            ((System.ComponentModel.ISupportInitialize)(wmPlayer)).EndInit();
            wmPlayer.uiMode = "none";
            wmPlayer.URL = @"C:\...";
            wmPlayer.settings.setMode("loop", true);
    
            wmPlayer.Ctlcontrols.play();
        }
