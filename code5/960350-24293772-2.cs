    using (SqlDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
    {
         if (await reader.ReadAsync())
         {
             if (!(await reader.IsDBNullAsync(0)))
             {
                using (var dataStream = reader.GetStream(0))
                {
                    //process the data
                }
              }
          }
    }
