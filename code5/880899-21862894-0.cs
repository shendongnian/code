     public class myClass
     {
         public Delegate myDelegate { get; set; }
 
         public myClass(Delegate d)
         {
             myDelegate = d;
         }
     }
     myClass myInstance = new myClass(new Func<int, int>(x => x * x));
      
