    private DateTime startUse;
    
    private void appPivot_LoadedPivotItem(object sender, PivotItemEventArgs e)
    {
      startUse = DateTime.Now;
    }
    
    private void appPivot_UnloadingPivotItem(object sender, PivotItemEventArgs e)
    {
      TimeSpan pivotUsage = DateTime.Now - startUse;
      // Save it somewhere regarding to SelectedPivotItem
    }
