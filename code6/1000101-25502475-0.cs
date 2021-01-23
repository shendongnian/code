    public class SomeClass 
    { 
      public SomeClass()
      {
        GenericMethod<Object1>(out result);
        ....
      }
      public void GenericMethod<Object1>(out Result result)
      {
         Object1 t = new Object1();
         Handle(t, result);
      }
      private void Handle(Object1 arg1, out Result result)
      {
        //do something need to be done for Object1;
      }
      private void Handle(Object2 arg1, out Result result)
      {
        //do something need to be done for Object2;
      }
      ....
    }
