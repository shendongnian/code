    public interface ITestService
    {
       [OperationContract]
       void SetField(string data);
       [OperationContract]
       string GetField();
    }
    public class TestService : ITestService
    {
      private static string myData;
      public string GetField()
      {
        retrun myData;
      }
      public void SetField(string data)
      {
         myData = data;
      }
    }
