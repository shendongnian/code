    try
    {
        ModuleAResult aResult = ModuleA.DoSomethingA();
        ModuleBResult bResult = ModuleB.DoSomethingB();
    }
    catch(ModuleAException ex)
    {
        // handle specific error
    }
    catch(ModuleBException ex)
    {
        // handle other specific error
    }
    catch (Exception ex)
    {
        // handle all other errors, do logging, etc.
    }
