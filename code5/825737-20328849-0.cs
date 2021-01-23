     public class DerivedClassExtraParameters<T>
     {
         internal T myFieldD;
         internal string myName;
         static public DerivedClassExtraParameters<T> CreateInstance(T value)
         {
             DerivedClassExtraParameters<T> instance = new DerivedClassExtraParameters<T>();
             instance.myFieldD = value;
             instance.myName = value.GetType().Name;
             return instance;
         }
     }
