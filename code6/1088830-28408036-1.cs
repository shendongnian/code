    using System.Threading;
    
    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
    player.Stream = Properties.Resources.ringtone;
    
    while (condition)
    {
        player.Play();
        Thread.Sleep(6000);
    }
