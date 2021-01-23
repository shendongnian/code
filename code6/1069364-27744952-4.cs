    private void TabControl_OnSelectionChanged(
      Object sender, SelectionChangedEventArgs eventArgs)
    {
      if ((eventArgs.OriginalSource as TabControl)?.SelectedItem == TabToBeHandled)
        SolveAllProblems();
    }
