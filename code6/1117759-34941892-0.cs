      public interface IService
        {
            
            [System.ServiceModel.XmlSerializerFormatAttribute()]
            [System.ServiceModel.OperationContract] 
            string GetData(int value);
         }
