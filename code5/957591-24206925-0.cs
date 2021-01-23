	class TableColumnIndexer
	{
		Dictionary<string, HashSet<string>> tables = new Dictionary<string, HashSet<string>>();
		public void Add(string tableName, string columnName)
		{
			this.Add(new TableColumns { Table = tableName, Column = columnName });
		}
		public void Add(TableColumns tableColumns)
		{
			if(! tables.ContainsKey(tableColumns.Table))
			{
				tables.Add(tableColumns.Table, new HashSet<string>());
			}
			tables[tableColumns.Table].Add(tableColumns.Column);
		}
		
		// .... More code to follow
