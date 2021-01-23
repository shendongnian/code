    public MyClass
    {
      private List<Foo> myFoo = new List<Foo>();
      
      //GUI Constructor will call a Load Function
      private void Load()
      {
         //Context is a DbContext entity
         var query = from q in context.Foo
           select q;
        // set the private member variable "myFoo" here
        datagrid.Datasource = myFoo = query.ToList();
      }
      private void TextFilter()
      {
        // don't requery the DB, query the list myFoo
        //var query = from q in context.Foo.Where( x => x.Name == FilterTextbox.Text )
        //select q;
        var query = myFoo.Where(x => x.Column == SearchCriteria).ToList();
       datagrid.Datasource = query;
     }
    }
