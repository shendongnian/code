      var gvColumns = GridView1.Columns;
      var viewName = EntityDataSource1.GetViewNames().First();
      var view = (EntityDataSourceView)EntityDataSource1.GetView(viewName);
      var schema = view.GetViewSchema();
      var dsColumns = schema.Columns;
       
      // each element in dsColumns has DataType and ColumnName properties      
      foreach (var c in dsColumns) Console.WriteLine("{0}: {1}", c.ColumnName, c.DataType);
      
      // now your code here to take this list and add ListItem for your drop down per each element.
