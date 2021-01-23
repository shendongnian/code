    public class DerivedClassExtraParameters<T>
         {
             internal T myFieldD;
             internal string myName;
             public DerivedClassExtraParameters(T value)
             {
                  myFieldD = value;
                  myName = value.GetType().Name;
             }
         }
