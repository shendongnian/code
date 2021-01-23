    // Add ‘ID’ column which is the primary key
    Column idColumn = new Column(table, "ID");
    idColumn.DataType = DataType.Int;
    idColumn.Identity = true;
    idColumn.IdentitySeed = 1;
    idColumn.IdentityIncrement = 1;
    // Create a primary key index
    Index index = new Index(table, string.Format("PK_{0}", table.Name));
    index.IndexKeyType = IndexKeyType.DriPrimaryKey;
    index.IndexedColumns.Add(new IndexedColumn(index, "ID"));
    table.Indexes.Add(index);
    // Add colums to table
    table.Columns.Add(idColumn);
