    // Not necessary
    public IPaymentable {
      void ProcessPayment();
    }
    
    // Interface should be implemented here
    public abstract class PaymentSystemBase: IPaymentable {
      ...
      private IDatabaseConnection connectToDatabase() {...}
      ...
      protected void loadFromDatabase() {...}
      protected void saveToDatabase() {...} 
      ...
      protected PaymentSystemBase() {...}
    
      public abstract void ProcessPayment();
    }
    
    // A concrete class should only override ProcessPayment() method
    public class PS1: PaymentSystemBase {
      public override void ProcessPayment() {...}
    }
    
    // A concrete class should only override ProcessPayment() method
    public class PS2: PaymentSystemBase {
      public override void ProcessPayment() {...}
    }
