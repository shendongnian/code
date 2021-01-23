    tasks.Add(Task.Run(async () => //Note Task.Run and async lambda
     {
          try
          {
            var comm = new WhateverCommand();
            ...
            var mysql_return = await comm.ExecuteNonQueryAsync();//Note the await
            ...
          }
          catch (MySql.Data.MySqlClient.MySqlException ex) 
          {
            Console.WriteLine(ex.Message);
          }    
    }));
