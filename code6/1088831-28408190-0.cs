    using System.Threading;
    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
    player.Stream = Properties.Resources.ringtone;
    Task.Run(()=>
    {
         while (true)
         {
            player.Play();
            Thread.Sleep(2000);
         }
    });
   
