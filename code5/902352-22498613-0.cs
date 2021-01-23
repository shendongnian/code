    [ServiceContract]
    IDestinationHelper
    {
      [OperationContract]
      IEnumerable<Waypoint> ReachDestination(string transportationMode);
      [OperationContract]
      IEnumerable<string> GetAvailabletransportationModes();
    }
    IDestinationHelperService : IDestinationHelper
    {
      public IEnumerable<Waypoint> ReachDestination(string transportationMode)
      {
         // decide return value by transportation mode. Use a switch statement, dependency injection, IoC containers, whatever you want
      }
      public IEnumerable<string> GetAvailabletransportationModes()
      {
         // decide return value by getting all modes from wherever you decided upon above.
      }
    }
