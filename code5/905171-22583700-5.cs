        class Helper
        {
          internal static System.ServiceModel.FaultException<Message> ConvertToSoapFault(MyException ex)
          {
              FaultCode fc = new FaultCode(ex.Code);
              return new FaultException<Message>(new Message(){ Text= ex.Message, Code= ex.Code});
          }
          internal static System.ServiceModel.FaultException ConvertToSoapFault(Exception ex)
          {            
              return new FaultException(ex.Message);
          }
        }
