    private void button1_Click(object sender, EventArgs e)
    {
        AxWMPLib.AxWindowsMediaPlayer wmplayer = new AxWMPLib.AxWindowsMediaPlayer();
        this.Controls.Add(wmplayer);
        wmplayer.Size = new Size(200, 200);
        wmplayer.enableContextMenu = false; //here it throws an exception
    }
