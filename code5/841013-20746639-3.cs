            var gvColumns = GridView1.Columns;
            var viewName = ((IDataSource)EntityDataSource1).GetViewNames().OfType<string>().First();
            
            var view = (EntityDataSourceView)((IDataSource)EntityDataSource1).GetView(viewName);
            var schema = view.GetViewSchema();
            var dsColumns = schema.Columns;
            var dvColumnsDict = gvColumns.OfType<BoundField>().ToDictionary(a => a.DataField);
            // ddlNames  is your ddl
            foreach (DataColumn c in dsColumns)
            {
                if (dvColumnsDict.ContainsKey(c.))
                {
                    var li = new ListItem(string.Format("{0}: {1}", c.ColumnName, c.DataType), c.ColumnName);
                    ddlColumns.Items.Add(li);
                }
            }
