    private void Application_FailuresProcessing(object sender, 
      FailuresProcessingEventArgs e)
    {
      FailuresAccessor failuresAccessor = e.GetFailuresAccessor();
      IEnumerable<FailureMessageAccessor> failureMessages =
        failuresAccessor.GetFailureMessages();
    
      foreach (FailureMessageAccessor failureMessage in failureMessages)
      {
        if (failureMessage.GetSeverity() == FailureSeverity.Warning)
          failuresAccessor.DeleteWarning(failureMessage)
      }
    
      e.SetProcessingResult(FailureProcessingResult.Continue)
    }
