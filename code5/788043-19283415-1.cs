    public class ViewModel1 : Person {
      private ViewModel2 _vm2;
      public ViewModel1(ViewModel2 vm2) {
        _vm2 = vm2;
      }
      public override string FirstName {
        get { return _vm2.FirstName; }
      }
      public override string LastName {
        get { return _vm2.LastName; }
      }
    }
