        public static void AddMediaPlayer(Form form1) {
            Button b1 = new Button();
            b1.Text = "Button";
            try {
                wmPlayer = new AxWMPLib.AxWindowsMediaPlayer();
                ((System.ComponentModel.ISupportInitialize)(wmPlayer)).BeginInit();
                wmPlayer.Name = "wmPlayer";
                wmPlayer.Enabled = true;
                wmPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
                form1.Controls.Add(wmPlayer);
                ((System.ComponentModel.ISupportInitialize)(wmPlayer)).EndInit();
                // After initialization you can customize the Media Player
                wmPlayer.uiMode = "none";
                wmPlayer.URL = @"C:\ProjectSilver\assets\RadarDetectie\general\inlog_confirm.ogv";
                wmPlayer.Ctlcontrols.play();
            }
            catch { }
