         [ServiceContract]
         public interface IService1
         {
            [OperationContract]
            string SaveFile(byte[]buffer, string fileName);
         }
