     public async Task Foo()
     {
         /// <snip />
         await conn.OpenAsync();
         /// <snip />
         await cmd.ExecuteNonQueryAsync();
         /// <snip />
     }
