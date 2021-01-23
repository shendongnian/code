    public async Task<IEnumerable<Foo>> LazyQueryAllFoos()
    {
       // NB : No `using` ... the reader controls the lifetime of the connection.
       var sqlConn = new SqlConnection(_connectionString);
       // Yes, it is OK to dispose of the Command https://stackoverflow.com/a/744307/314291
       using (var cmd = new SqlCommand(
            $"SELECT Col1, Col2, ... FROM LargeFoos", mySqlConn))
       {
          await mySqlConn.OpenAsync();
          var reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
          // Return the IEnumerable, without actually materializing Foos yet.
          // Reader and Connection remain open until caller is done with the enumerable
          return GenerateFoos(reader);
       }
    }
    // Helper method to manage lifespan of foos
    private static IEnumerable<Foo> GenerateFoos(IDataReader reader)
    {
        using(reader)
        {
           while (reader.Read())
           {
              yield return new Foo
              {
                  Id = Convert.ToInt32(reader["Id"]),
                  ...
              };
           }
        } // Reader is Closed + Disposed here => Connection also Closed.
    }
