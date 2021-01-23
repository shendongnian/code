      private void btnPause_Click(object sender, EventArgs e)
      {
            if (_mp3Player != null)
            {
                _mp3Player.Stop();
            }
            btnPause.Visible = False;
            btnPlay.Visible = True;
      }
