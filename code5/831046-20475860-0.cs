    public void PlayAll()
        {
            pb.Maximum = Convert.ToInt32(ListSize();  //Total lenght of the full song.
            pb.Step = 1;
            int i = 1;
            foreach (MusicNote m in list)
            {
                m.sp.Stop();
                m.sp.Play();
                Thread.Sleep(m.NoteDuration * 100);
                pb.Value = i++;
            }
        }
