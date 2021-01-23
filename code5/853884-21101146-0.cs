    public class A
    {
       public int Index{get;set;}
    
       public B ConfigOne{get;set;}
       public B ConfigTwo{get;set;}
    
       public void SetConfigOne(string val1, string val2);
       public void SetConfigTwo(string val1, string val2);
    
    
       //This method exposes the new functionality
       public void setVal1OfConfig1(string value){
           ConfigOne.Val1 = value;
       }
    }
    
    public class B
    {
       protected string Val1{get;set;}
       protected string Val2{get;set;}
    }    
