     IPaypal
     {
         //PayPal specific methods
     }
     IStripe
     {
         //Stripe specific methods
     }
     MyAbstractClass : IPaypal, IStripe //Other interfaces
     {
         //Method implementation for all of the inherited methods
     }
     MyPaymentClass : MyAbstractClass
     {
          //stuff
     }
     {
           var payment = new MyPaymentClass();
           payment.paypalMethod;
     }
         
     
