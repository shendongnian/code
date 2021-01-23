    public class A
    {
       public int Index{get;set;}
    
       public B ConfigOne{get; }
       public B ConfigTwo{get; }
    
    }
    
    public class B
    {
       
       public B(string val1, string val2)
       {
           this.Val1 = val1;
           this.Val2 = val2;
       }
       public string Val1{get; private set;}
       public string Val2{get; private set;}
    }
