    Class Day{
    
    public string Day{get;set;} // use enum for better coding
    public DateTime Time{get;set;}
    }
    
    Class Program{
    
    public string File Path{get;set;}
    Public string File Name{get;set;}
    Public List<Day> Days{get;set;}
    }
    
    // Now you can store the information object 
    
    List<Program> Programs= new List<Program>();
