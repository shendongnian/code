     public IEnumerable<MyClass> GetList()
     {
         foreach (var item in SomeList)
         {
              yield return new MyClass();
         }
     }
