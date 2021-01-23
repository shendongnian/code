    public Task RunCommand(CancelationToken cancel)
    {
    
        using(var connection = new DbConnection())
        {
            connection.Open();
            using(var command = connection.CreateCommand())
            {
                //setup the command
                await command.ExecuteNonQueryAsync(cancel.Token);
            }
       
        }
    }
    public void Main()
    {
        var cancel = new CancellationTokenSource();
        RunCommand(cancel.Token);
        cancel.Cancel();
    }
