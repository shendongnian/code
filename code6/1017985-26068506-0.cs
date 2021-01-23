    public abstract class TowInt
    {    
       public virtual string getAnswer() {
           return "Hello from Base-Class";
      }    
    }
    public class TwoIntDivision : TowInt
    {
       public override string getAnswer() {
            return "Hello from Division";
       }
    }
    TowInt t = new TwoIntDivision();
    Console.WriteLine(t.getAnswer());     // prints "Hello from Division"
