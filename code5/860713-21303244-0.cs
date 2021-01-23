    //Untested code, but should give you an idea.
    string[] files = Directory.GetFiles("path");
    Random rnd = new Random(Guid.NewGuid().GetHashCode());
    int choice = rnd.Next(0, files.Length - 1);
    string soundFile = files[choice];
    System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundFile);
    player.Play();
