    player = new VlcControl();
    
    panel1.Controls.Add(player);
    player.BackColor = System.Drawing.Color.Black;
    player.ImeMode = System.Windows.Forms.ImeMode.NoControl;
    player.Location = new System.Drawing.Point(0, 0);
    player.Name = "test";
    player.Rate = 0.0F;
    player.Size = new System.Drawing.Size(1024, 768);
    
    Vlc.DotNet.Core.Medias.MediaBase media = new 
        Vlc.DotNet.Core.Medias.PathMedia(@"path\movie.avi");
    player.Media = media;
    player.Play();
