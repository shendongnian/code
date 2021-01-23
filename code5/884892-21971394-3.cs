      [ServiceContract(Namespace="ConsoleAJAXWCF")]
      public interface IService1
      {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string GetTEST();
      }
    
      [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
      public class Service1 : IService1
      {
        
        public string GetTEST()
        {
          return "OKKKKKKKK";
        }
      }
