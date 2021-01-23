    private void ActivateLikesOnList(SPList list)
    {
      try
      {
        System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("Microsoft.SharePoint.Portal, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c");
        Type reputationHelper = assembly.GetType("Microsoft.SharePoint.Portal.ReputationHelper");
        System.Reflection.MethodInfo method = reputationHelper.GetMethod("EnableReputation", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        
        method.Invoke(null, new Object[] { list, "Likes", false });
      }
      catch (Exception ex)
      {
        String msg = "Error while activating Likes on List" + " : {0} :: {1} :: {2}";
        _DiagnosticService.WriteTrace(0, _DiagnosticCategory, TraceSeverity.Medium, msg, ex.Message, ex.StackTrace, ex.TargetSite);
      }
    }
