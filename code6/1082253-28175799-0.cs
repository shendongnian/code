    using(OleDbConnection cnn = new OleDbConnection("...."))
    {
        cnn.Open();
        DataTable schemaIndexes = cnn.GetSchema("Indexes");
        foreach(DataRow row in schemaIndexes.Rows)
        {
           Console.WriteLine("Table={0}, Index={1} on field={2}",
               row.Field<string>("TABLE_NAME"),
               row.Field<string>("INDEX_NAME"),
               row.Field<string>("COLUMN_NAME"));
        }
    }
