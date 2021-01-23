    if (pause) {
      for (int i = 0; i < pbs.Length; i++) {
        pbs[i].ContinueAnimate();
      }
    } else {
      for (int i = 0; i < pbs.Length; i++) {
        pbs[i].PauseAnimate();
      }
    }
    pause = !pause;
