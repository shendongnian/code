    public void PlayAll()
    {
        pb.Maximum = list.Length; //Or equivalent, perhaps ListSize()?
        pb.Step = 1;
        foreach (MusicNote m in list)
        {
            m.sp.Stop();
            m.sp.Play();
            Thread.Sleep(m.NoteDuration*100);
            pb.PerformStep();
        }
    }
