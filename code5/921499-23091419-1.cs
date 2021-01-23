    [DataContract]
    public class Info
    {
      [DataMember]
      public string Key { get; set; }
      [DataMember]
      public string Value { get; set; }
    
      public Info(string key, string value)
      {
        this.Key = key;
        this.Value = value;
      }
    }
