    public class PersonRepository : BaseRepository
    {
	    public PersonRepository(string connectionString): base (connectionString) { }
        // Assumes you have a Person table in your DB that 
	    // aligns with a Person POCO model.
	    //
	    // Assumes you have an existing SQL sproc in your DB 
	    // with @Id UNIQUEIDENTIFIER as a parameter. The sproc 
	    // returns rows from the Person table.
        public async Task<Person> GetPersonById(Guid Id)
	    {
		    return await WithConnection(async c =>
		    {
			    var p = new DynamicParameters();
			    p.Add("Id", Id, DbType.Guid);
			    var people = await c.QueryAsync<Person>(sql: "sp_Person_GetById", param: p, commandType: CommandType.StoredProcedure);
			    return people.FirstOrDefault();
		    });
	    }
    }
