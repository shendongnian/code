     class GenericTypeTester
     {
       public Type Test<T>(T dog) where T : IPet, class
       {
         return typeof (T);
       }
     }
  
