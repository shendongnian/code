    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    [Serializable()]
    public class AppState
    {
         public int HPValue {get; set;}
         .... other variables to store/read from the serialization stream
    }
