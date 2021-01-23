      public T tryLoop<T>(Func<T> anyMethod)
      {
         while (true)
         {
            try
            {
               return anyMethod();
               break;
            }
            catch
            {
               System.Threading.Thread.Sleep(2000); // wait 2 seconds
            }
         }
         return default(T);
      }
      void SomeMethod(int param)
      {
         var someLocal = "Hi";
         var anotherLocal = 0;
         var result = tryLoop(() =>
         {
            Console.WriteLine(someLocal);
            return param + anotherLocal;
         });
         Console.Write(result);
      }
