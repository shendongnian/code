    private void TabControl_OnSelectionChanged(
      Object sender, SelectionChangedEventArgs eventArgs)
    {
      var tabControl = eventArgs.OriginalSource as TabControl;
      if (tabControl != null)
        SolveAllProblems();
    }
