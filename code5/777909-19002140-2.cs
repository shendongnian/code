    [ServiceContract]
    public interface IWCF
    {
        [OperationContract]
        bool method1();
        [OperationContract]
        bool method2();
    }
     [ServiceContract]
    public interface IConnectionWCF
     {
         [OperationContract]
         bool SetConnection(string connection);
     }
     public class WCF : IWCF, IConnectionWCF
    {
         public bool method1()
         {
            ...
         }
         public bool method2()
         {
            ...
         }
         public bool SetConnection(string connection)
         {
             ...
         }
    }
