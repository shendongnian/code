      public static T Multiply<T>(T A, int B)
      {
         T val = default(T);
         try
         {
            val = (dynamic)A * B;
         }
         catch
         { }
         return val;
      }
