    Task.Factory.StartNew(() => 
    {
        sound.Play();
        // Wait for the sound to finish playing!
        AutoResetEvent.WaitOne();  // Note that this can take an optional time out so you can limit how long your program waits, if you want to.
        for(int i = 0; i < 150; i++)
        {
            LabelNameContent = i.ToString();
            Thread.Sleep(500);
        }
    });
