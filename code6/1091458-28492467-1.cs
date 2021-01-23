    public abstract class ClassCommon
    {
         public abstract string PropertyA {get; }
         public abstract string PropertyB {get; }          
    }
    
    public abstract class ClassA : ClassCommon
    {              
         public string PropertyX {get; set;}          
    }
    
    
    public abstract class ClassB : ClassA
    {     public string PropertyY {get; set;}          
    }
   
