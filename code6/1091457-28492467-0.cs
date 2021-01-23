    public abstract class ClassCommon
    {
         public abstract string PropertyA {get; }
         public abstract string PropertyB {get; }          
    }
    
    public abstract class ClassA : ClassCommon
    {              
         public string PropertyX {get; set;}          
    }
    
    
    public abstract classC1 : ClassA
    {     public string PropertyY {get; set;}          
    }
   
