     [JsonObject()]
     public class MyDictionaryType : Dictionary<MyStruct, MyObject>
     {
     }
    
    
     [DataContract(IsReference = true)] 
     public abstract class Entity 
     {
         [DataMember]
         protected MyDictionaryType  MyDict;
    
         ... 
     }
