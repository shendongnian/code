    using System.Threading;
    using System.Threading.Tasks;
    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
    player.Stream = Properties.Resources.ringtone;
    private void LoopSong()
    {
         while(true)
         {
             player.Play();
             Thread.Sleep(2000);
         }
    }
    var thread = new Thread(LoopSong) 
    {
        IsBackground = true
    };
    thread.Start();
