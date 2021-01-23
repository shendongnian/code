    public class MyFooClass
    {
       public int DoFooFooData(FooAdapter Foo)
       {
         Data.Foo.FooDataTable tbl = Adapter.GetFooByID(id);
         //just imagining what you might do here.
         int total=0;
         foreach (Data.Foo.FooRow row in tbl)
         {
           x = row.bar
           //just imagining what you might do here.
           total+=x;
        }
        return total;
      }
    }
