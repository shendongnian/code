    private int counter = 0;
    private Random rd = new Random();
    private void playMyAudioFile(object sender, EventArgs e)
    {
        i = rd.Next(1, 26);            
        mediaElement1.Source = new Uri(@"D:\Project C#\A-Z\" + i + ".mp3");
        mediaElement1.Play();
        ++counter;
        if (counter == 5)
        {
            dispatcherTimer.Stop();
        }
    }
