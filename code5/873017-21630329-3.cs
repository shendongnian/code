    if (pause)
    {
      for (int i = 0; i < pbs.Length; i++)
      {
        pbs[i].ContinueAnimate();
      }
      pause = false;
    }
    else
    {
      for (int i = 0; i < pbs.Length; i++)
      {
        pbs[i].PauseAnimate();
      }      
      pause = true;
    }
