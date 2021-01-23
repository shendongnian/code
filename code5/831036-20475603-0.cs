    public void PlayAll()
    {
        pb.Maximum = Convert.ToInt32(CountTotalDuration());  //Total lenght of the full song.
        int currentCount = 0; //Set the 
        foreach (MusicNote m in list)
        {
            m.sp.Stop();
            m.sp.Play();
            Thread.Sleep(m.NoteDuration*100);
            //Increment the progress bar proportional to the length of the note.
            currentCount += m.NoteDuration;
            //Set the progress bar using our calculated position.
            pb.Value = currentCount;
        }
    }
