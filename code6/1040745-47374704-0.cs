    public async Task<Foo> GetOneFoo(int idToFetch)
    {
       using (var myConn = new SqlConnection(_connectionString))
       using (var cmd = new SqlCommand("SELECT Id, Col2, ... FROM Foo WHERE Id = @Id"))
       {
          await myConn.OpenAsync();
          cmd.Parameters.AddWithValue("@Id", idToFetch);
          using (var reader = await cmd.ExecuteReaderAsync())
          {
             var myFoo = new Foo
             {
                Id = Convert.ToInt32(reader["Id"]),
                ... etc
             }
             return myFoo; // We're done with our Sql data access here
          } // Reader Disposed here
       } // Command and Connection Disposed here
    }
