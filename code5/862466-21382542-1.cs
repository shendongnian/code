    void BCP<TRow> (IEnumerable<TRow> rows)
    {
        if (rows.Count() == 0) return;
        var dt = new DataTable ();
        var metaTable = _db.Mapping.GetTable (typeof (TRow));
        var columns = metaTable.RowType.DataMembers.Where (dm => dm.Association == null);
        var transformers = new List<Func<TRow, object>>();
        foreach (var columnX in columns)
        {
            var column = columnX;
            dt.Columns.Add (column.Name, L2sToDataTable (column.Type));
            transformers.Add (row => L2sToDataTable (row.GetType().GetField (column.Name).GetValue (row)));
        }
        foreach (var row in rows)
            dt.Rows.Add (transformers.Select (t => t (row)).ToArray());
    
        _db.Connection.Open();
        Console.Write ("Bulk copying " + metaTable.TableName + "... ");
        var bcp = new SqlBulkCopy ((SqlConnection)_db.Connection) { DestinationTableName = metaTable.TableName, BulkCopyTimeout = 300 };
        bcp.BatchSize = 20;
        bcp.NotifyAfter = 20;
        bcp.SqlRowsCopied += (sender, args) => Console.Write (args.RowsCopied + " rows... ");
        bcp.WriteToServer (dt);
        _db.Connection.Close();
        Console.WriteLine ("Done");
    }
    Type L2sToDataTable (Type l2sType)
    {
    	if (l2sType == typeof (Binary)) return typeof (byte[]);
    	if (l2sType.IsGenericType && l2sType.GetGenericTypeDefinition() == typeof (Nullable<>)) return l2sType.GetGenericArguments()[0];
    	return l2sType;
    }
    
    object L2sToDataTable (object l2sValue)
    {
    	if (l2sValue == null) return DBNull.Value;
    	if (l2sValue is Binary) return ((Binary) l2sValue).ToArray();
    	return l2sValue;
    }
