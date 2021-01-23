    class OtherClassInTheSameNamespace
    {
       private void SomeMethod()
       {
          var localVariable = CrossClassObject.MyField; // get 'cross-class' field MyField
    
          CrossClassObject.MyMethod(); // execute 'cross-class' method MyMethod()
       }
    }
