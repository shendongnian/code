    // introduce a new variable
    bool isPaused 
    
    // for the pausing/resuming action
    if(isPaused)
    {
       Time.timeScale = 1;
       isPaused = !isPaused;
    }
    else
    {
       Time.timeScale = 0;
       isPaused = !isPaused;
    }
    // On your 'if (Input.GetButtonDown ("Horizontal"))' line
    if (Input.GetButtonDown ("Horizontal") && !isPaused)
