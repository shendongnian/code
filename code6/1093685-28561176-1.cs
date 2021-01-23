       public class MyBaseClass
       {
          [JsonProperty("BaseProp1")]
          public string BaseProp1 { get; set; }
          [JsonProperty("BaseProp2")]
          public string BaseProp2 { get; set; }
       }
    
       [DataContract]
       public class MyDerivedClass : MyBaseClass
       {
          [JsonProperty("DerProp1")]
          [DataMember]
          public DateTime DerProp1 { get; set; }
          [JsonProperty("DerProp2")]
          public string DerProp2 { get; set; }
       }
