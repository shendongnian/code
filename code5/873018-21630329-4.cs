    public void globalPb_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Middle)
      {
        for (int i = 0; i < pbs.Length; i++)
        {
          AnimatePauseOrContinue(pause, pbs[i]);
        }
        pause = !pause;
      }
    }
    public void AnimatePauseOrContinue(bool shouldPause, pbType pb)
    {
      if (shouldPause)
        pb.PauseAnimate();
      else
        pb.ContinueAnimate();
    }
