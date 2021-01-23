    public void ModuleA.DoSomethingA()
    {
        throw new Exception("Error in module A");
    }
    try
    {
        ModuleAResult aResult = ModuleA.DoSomethingA();
        ModuleBResult bResult = ModuleB.DoSomethingB();
    }
    catch (Exception ex)
    {
        // get information about exception in the error message
    }
