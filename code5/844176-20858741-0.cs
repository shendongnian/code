    public class ViewModel1
    {
       public ViewModel2 {get;set;}
       public ViewModel1()
       {
          this.ViewModel2 = new ViewModel2(); //or you can send  ViewModel2 instance as a parameter
       }
    } 
