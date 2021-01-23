    progressBar.Step = 1;
	progressBar.Minimum = 0;
	progressBar.Maximum =  elements.Count;
    ...
    
    for (int index = 0; index < progressBar.Maximum; index++)
    {
      // Do your work here ...
      
      progressBar.PerformStep();
    }
