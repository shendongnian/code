    public class MyProductionEnvironmentService : IEnvironmentService
    {
      public IEnumerable<string> GetCommandLineArguments()
      {
        return Environment.GetCommandLineArgs();
      }
    }
