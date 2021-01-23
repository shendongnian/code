    public sealed class MyClassMap : CsvClassMap<MyClass>
    {
         public MyClassMap()
         {
             Map(m => m.field1).Index(0);
             Map(m => m.field2).Index(1);
             Map(m => m.field3).Index(2);
         }
     }
