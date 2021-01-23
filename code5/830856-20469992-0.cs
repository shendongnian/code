    public void PlayAll()
    {
        foreach (MusicNote m in musicNotes)
        {
            m.sp.Stop();
            m.sp.PlaySync();
            Thread.Sleep(m.noteDuration); //duration should be in milliseconds
        }
    }
