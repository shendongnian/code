    class OtherClassInTheSameNamespace
    {
       private void SomeMethod()
       {
          var localVariable = CrossClassObject.MyProperty; // get 'cross-class' property MyProperty
    
          CrossClassObject.MyMethod(); // execute 'cross-class' method MyMethod()
       }
    }
