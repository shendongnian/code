    var columnType = myDataTable.Columns[countField].DataType;
    var method = typeof(DataRowExtensions).GetMethod("Field", new Type[] { typeof(DataRow), typeof(string) });
    var generic = method.MakeGenericMethod(columnType);
    
    var query = from row in myDataTable.AsEnumerable()
    			group row by generic.Invoke(null, new object[] { row, countField })
    			into sumry
    			orderby sumry.Count() descending
    			select new
    			{
    				Text = sumry.Key,
    				CountOfRows = sumry.Count()
    			};
