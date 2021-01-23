    public interface IBeverage { 
      double Price { get; } 
    }
    public abstract class Beverage : IBeverage {
      public abstract double Price { get; }
    }
    public class Coffee : Beverage { 
      public override double Price {
        get {
          return 3.00;
        }
      }
    }
    public class Tea : Beverage { 
      public override double Price {
        get {
          return 2.00;
        }
      }
    }
    public class Cream : Beverage { 
      public override double Price { 
        get { 
          return .15;
        }
      }
    }
