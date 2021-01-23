    public class EncryptionExtension : SoapExtension { 
   
      public override void ProcessMessage(SoapMessage message) {
        switch (message.Stage) {
          case SoapMessageStage.BeforeSerialize:
           break;
          case SoapMessageStage.AfterSerialize:
            Encrypt();
            break;
          case SoapMessageStage.BeforeDeserialize:
            Decrypt();
            break;
          case SoapMessageStage.AfterDeserialize:
            break;
          default:
            throw new Exception("invalid stage");
          }
       }
    ...
    }
