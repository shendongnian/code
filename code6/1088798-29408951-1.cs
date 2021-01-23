    namespace UTExtension
    {
      [ NUnitAddinAttribute(Type = ExtensionType.Core)]
      public class ExtensionToLog: IAddin, EventListener
      {
    #region IAddin Members
    
    public bool Install(IExtensionHost host)
    {
      if (host == null)
        throw new ArgumentNullException("MyExtension.Install() method has failed beacuse 'host' is NULL");
      IExtensionPoint listeners = host.GetExtensionPoint("EventListeners");
      if (listeners == null)
        return false;
      listeners.Install(this);
      return true;
    }
    #endregion
    #region Event Listener Members
    /// <summary>
    /// This method is executed before the TearDown test method.
    /// When the test method will fail then in order to get the failure message we will use the method below. 
    /// </summary>
    public void TestFinished(TestResult result)
    {
      if ((result.Message == null) && result.Executed && (result.ResultState == ResultState.Success))
      {
        // the single test METHOD has passed
        Console.Out.WriteLine("\t\tPassed\n");
      }
      else if(result.Message != null)
      {
        // something goes wrong
        string errorMsg = null;
        errorMsg = result.Message;
        errorMsg = Regex.Replace(errorMsg, @"\s+", " ");
        // an assert fails during the single test method
        bool assertFails= result.Executed && (result.ResultState == ResultState.Failure);
        // an exception occurrs during the single test method
        bool exeptionOccurrs = result.Executed && (result.ResultState == ResultState.Error);
        if (assertFails || exeptionOccurrs)
        {
          
          Console.Out.WriteLine("\t\tFailed\n");
        }
        else
        {
          // if an exception occurred during the load of the test environment
          bool loadingExeptionOccurrs = result.Executed && (result.ResultState == ResultState.Error);
          if (loadingExeptionOccurrs)
          {
              Console.Out.WriteLine("\nException --> " + errorMsg);
          }
        }
      }
    }
    private static bool TestMethodError = false;
    /// <summary>
    /// This method is executed before the FixtureTearDown test method. 
    /// </summary>
    public void SuiteFinished(TestResult result)
    {
      // an exception occurred during the load of the test environment
      bool loadingExeptionOccurrs = result.Executed && (result.ResultState == ResultState.Failure);
      if (!loadingExeptionOccurrs || TestMethodError)
      {
        
      }
      TestMethodError = false; // reset the variable
    }
    public void RunStarted(string name, int testCount)
    {
      Console.Out.WriteLine("Run has started: name= " + name + "; test count= " + testCount);
    }
    public void RunFinished(TestResult result)
    {
      Console.Out.WriteLine("\n\nRUN HAS FINISHED: " + result.Name + " ; message: " + result.Message);
    }
    public void RunFinished(Exception exception)
    {
      Console.Out.WriteLine("\n\nRUN HAS FINISHED: " + exception.Message);
    }
    public void TestStarted(TestName testName)
    {
      Console.Out.WriteLine("\t\tTest method: " + testName.Name);
    }
    // This methos will be executed before the 'TestFixtureSetUp' method
    public void SuiteStarted(TestName testName)
    {
      Console.Out.WriteLine("Test Class: " + testName.Name);
    }
    public void UnhandledException(Exception exception)
    {
      Console.Out.WriteLine("Suite has finished: " + exception.Message);
    }
    public void TestOutput(TestOutput testOutput)
    {
    }
    #endregion
     }
     }
