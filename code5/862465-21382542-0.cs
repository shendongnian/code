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
