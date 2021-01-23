      var gvColumns = GridView1.Columns;
      var viewName = EntityDataSource1.GetViewNames().First();
      var view = (EntityDataSourceView)EntityDataSource1.GetView(viewName);
      var schema = view.GetViewSchema();
      var dsColumns = schema.Columns;
      var dvColumnsDict = dvColumns.OfType<BoundField>().ToDictionary(a=>a.DataField);      
       // ddlNames  is your ddl
      foreach (var c in dvColumns) {
          if (dvColumnsDict.ContainsKey(c.ColumnName)) {
             var li = new ListItem(string.Format("{0}: {1}", c.ColumnName, c.DataType), c.ColumnName);
             ddlColumns.Add(li);
          }
      }
