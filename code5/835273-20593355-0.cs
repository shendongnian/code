    public class ClassA
    {
       public ClassA()
       {
          this.ClassB = new ClassB();
       }
       public string Wish { get; set;}
       public ClassB ClassB { get; set;}
    }
