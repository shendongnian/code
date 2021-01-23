    public class class1
    {
    
    [DataMember]
    public string version {get;set;}
    
    [DataMember]
    public List<class2> results {get;set;}
    
    }
    
    public class class2
    {
    
    [DataMember]
    public string company {get;set;}
    
    
    [DataMember]
    public string city{get;set;}
    
    [DataMember]
    public string state {get;set;}
    
    
    }
