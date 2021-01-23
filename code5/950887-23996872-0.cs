    using System;
    using FConvert = Foo.Convert;
    public class Bar
    {
         public void Test()
         {
              var a = Convert.ToInt32("1");
              var b = FConvert.ToInt32("1");
         }
    }
