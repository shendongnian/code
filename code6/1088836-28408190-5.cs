    using System.Threading;
    using System.Threading.Tasks;
    
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
   
