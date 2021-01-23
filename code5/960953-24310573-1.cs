    private async Task<PortalODataContext> CallConnection(Connection connection)
    {
        bool cancel = false;
        connection.Connected = true;
        var task = getConnection(connection);
        while (!cancel && !task.IsCompleted)
        {
            await Task.Delay(100);
            if (connection.Disconected)
            {
                cancel = true;
            }
        }
        return await task;
    }
