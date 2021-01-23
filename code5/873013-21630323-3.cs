    for (int i = 0; i < pbs.Length; ++i) {
      if (paused) {
        pbs[i].ContinueAnimate();
      } else {
        pbs[i].PauseAnimate();
      }
    }
    pause = !pause;
