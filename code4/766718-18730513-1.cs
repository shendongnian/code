    public void DoFooFooData(IFooAdapter Foo)
        {
           Data.Foo.FooDataTable tbl = Adapter.GetFooByID(id);
             int total=0;
             foreach (Data.Foo.FooRow row in tbl)
             {
               x = row.bar
               //just imagining what you might do here
               total+=x;
            }
            return total;
        }
