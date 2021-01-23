    private void btPlayMin_Click(object sender, EventArgs e)
    {
        settingsYTP(sender, e, link, "Normal", new Size(300, 24), new Size(400, 95), false, "", FormBorderStyle.FixedToolWindow, true);
        int x = Screen.PrimaryScreen.WorkingArea.Width - 375;
        ytplayer.Location = new Point(x, 0);
        ytplayer.Show();
        this.Close();
    }
    private void btPlayNorm_Click(object sender, EventArgs e)
    {
        settingsYTP(sender, e, link, "Minimal", new Size(300, 240), new Size(400,335), true, "YoutubePlayer", FormBorderStyle.FixedSingle, false);
        ytplayer.Show();
        this.Close();
    }
    private void settingsYTP(object sender, EventArgs e, string link, string minmax,Size size1, Size size2, bool b1, string text,FormBorderStyle bs, bool b2)
    {
        ytplayer.playLink(sender, e, link);
        ytplayer.miniMax(minmax, size1, size2, b1, text, bs, b2); 
        ytplayer.TopMost = true;
        ytplayer.BringToFront();
        ytplayer.TopMost = false;
    }
