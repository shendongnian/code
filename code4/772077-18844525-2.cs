    public void OpenVideoPlayer()
    {
        VideoPlayer vp = new VideoPlayer();
        vp.Closed += vp_Closed;
        this.Hide();
        vp.Show();
    }
    void wnd_Closed(object sender, EventArgs e)
    {
        this.Show();
    }
