        var toDelete = myDataTable.AsEnumerable().Where(a => a.ItemArray.Count(b => b == DBNull.Value)== 1);
        foreach (var row in toDelete)
        {
            row.Delete();
        }
        myDataTable.AcceptChanges();
