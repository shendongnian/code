    private void TabControl_OnSelectionChanged(
      Object sender, SelectionChangedEventArgs eventArgs)
    {
      if (eventArgs.OriginalSource == NameOfTabToBeListenedTo)
        SolveAllProblems();
    }
