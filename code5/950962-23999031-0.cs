    foreach (DataRow row in dataTable.Rows)
    {
        int? id = row.Field<int?>("ID");
        if(id.HasValue)
        {
            Console.Write("ID: " + id.Value);
        }
    }
