    private void button3_Click(object sender, EventArgs e)
    {
        var AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        axWindowsMediaPlayer1.URL = Path.Combine(AssemblyPath, "dreammusic\\DrmMTrack8.lite.mp3");
    }
