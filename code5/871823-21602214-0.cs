    public class Base
    {
        public int Number = 0;
    }
    public class Derived : Base
    {
       public int Number;
      
       public Derived() 
       {
           this.Number = base.Number + 5;
       }
    }
