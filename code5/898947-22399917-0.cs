    [DataContract]
    public class CombinedObject{
           [DataMember(Name="token")]
           public string token {get; set; }    
           [DataMember(Name="model")]
           public LocalDatabaseModel model {get; set; }    
    
    }
