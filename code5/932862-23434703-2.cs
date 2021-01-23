    [DataContractAttribute]
    public class YourPageVars{
       [DataMember]
       public Boolean Value1 = false;
    
       [DataMember]
       public String Value2 = "And so on";
    
       [DataMember]
       public List<String> MultipleValues;
    }
