    using(var connection = new SqlConnection(connectionString))
    {
        var connectionTask = connection.OpenAsync();
        // other code goes here
        Task.WaitAll(connectionTask); //make sure the task is completed
        if(connectionTask.IsFaulted) // in case of failure
        {
           throw new Exception("Connection failure", connectionTask.Exception);
        }
        // rest of the code
     }
