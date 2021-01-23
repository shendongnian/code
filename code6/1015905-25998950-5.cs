    class TestService : Service
	{
        // Stores a single Table1 record
		public int Post(Table1 request)
		{
			// Add your method to store a single record
            var CRUD = new CRUDFunctions(Db);
            return CRUD.AddData(request); // Return the ID of the created record
		}
        // Stores multiple Table1 records
		public List<int> Post(Table1Multiple request)
		{
            // Return a list of the record Ids
			var result = new List<int>();
			// Process each request, through the single record code
			foreach(var value in request) // Collection changed here
				result.Add(Post(value));
			return result;
		}
	}
