    namespace Program {
	  class MyGeneric<T> { }
	  class MyDerived : MyGeneric<String> { }
      class Program {
        public static void Main() {
          MyDerived item = new MyDerived ();
          Boolean isIt = typeof(MyGeneric<>).BaseType.IsAssignableFrom (item.GetType());
          Console.WriteLine (isIt); // Output: "True"
          foreach (Type type in item.GetType().BaseType.GetGenericArguments())
            Console.WriteLine(type.Name);
        }
      }
    }
