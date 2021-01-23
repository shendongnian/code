    public class BaseClass {
      public virtual void VMedthod() {
        Console.WriteLine("base");
      }
    }
    public class SubClass : BaseClass {
      public override void VMethod() {
        Console.WriteLine("sub");
      }
    }
