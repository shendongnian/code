	using (var bulkCopy = new SqlBulkCopy(...)) {
		string database = "myDatabase";
		bulkCopy.SqlRowsCopied += (o, e) => {
			Console.WriteLine(
				"Time: {0}, database: {1}, rows copied: {2}", 
				DateTime.Now, database, e.RowsCopied
			);
		};
		bulkCopy.WriteToServer(...);
	}	
