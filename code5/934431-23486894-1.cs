    Files.CollectionChanged += EvaluateIsPrintAllowed;
    
    
    private void EvaluateIsPrintAllowed()
    {
         IsPrintAllowed = Files != null && Files.Count > 0;
    }
