     public class MyCustomClass
     {
          public void SomeMethod(object o, int i, Point p)
          {
                //Guards
                Ensure.NotNull(o, "o");
                Ensure.GreaterThanZero(i, "i");
                Ensure.NotZero(p, "p");
          }
     }
