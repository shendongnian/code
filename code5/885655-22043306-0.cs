    public class TerminalService : ITerminalService
    {
      public TerminalService(IPOSJobService posJobService){}
    }
    
    public class POSJobService : IPOSJobService
    {
      public class POSJobService(ITerminalService terminalsService){}
    }
