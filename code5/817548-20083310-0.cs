    public class SomeFoo
    {
      public string SomeTextValue {get; set;}
    }
    public class SomeDerivedFoo : SomeFoo
    {
      private SomeDerivedFoo();
      public static SomeDerivedFoo CreateFromSomeFoo(SomeFoo someFoo)
      {
         base.SomeTextValue = //scrub your data here;
      }
    }
