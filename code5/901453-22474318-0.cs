    try
     {
        ModuleAResult aResult = ModuleA.DoSomethingA();
        ModuleBResult bResult = ModuleB.DoSomethingB();
     }
    catch (Exception ex)
     {
       string errorMessage = string.Format("Either Module A or B failed", ex.Message);
    // Log exception, send alerts, etc.
     }
