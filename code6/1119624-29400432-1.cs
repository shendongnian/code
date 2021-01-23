    System.Media.SoundPlayer mediaPlayer = new System.Media.SoundPlayer(@"c:\Sound.wav");
        
    public void button1_MouseHover(object sender, EventArgs e)
    {
       mediaPlayer.Play();
    }
