    for (int i = 0; i < 6; i++)
    {
        button1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(arr1[i]);
        Application.DoEvents();
        new SoundPlayer(Properties.Resources.nero).Play();
        Thread.Sleep(5000);
    }
