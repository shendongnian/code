    <%@ ServiceHost Language="C#" Debug="true" Service="TestService.Service2" %>
    using System;
    using System.ServiceModel;
    namespace TestService
    {
      [ServiceContract]
      public interface IService2
      {
        [OperationContract]
        string GetData(int value);
      }
      public class Service2 : IService2
      {
        public string GetData(int value)
        {
          return "You entered: " + value;
        }
      }
    }
