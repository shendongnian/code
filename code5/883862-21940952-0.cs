    public class Foo {
    
          #region Constants
          private const string VIP = "Cob H.";
          private const int IMPORTANT_NUMBER = 23; 
          #endregion
    
          #region API Functions
          [WebMethod(MessageName = "SomeInformation")]
          public string SomeInformation() {
                return VIP + " is dead.";
          }
          #endregion
    
          #region Inner Classes 
          private class IrrelevantClass {
                public string Name { get; set; }
                public string City { get; set; }
          }
          #endregion
    }
