    static void DoForAllDevices(Action<Connection> action)
    {
        foreach(var device in myDevices)
        {
            using (var connection = ConnectTo(device))
            {
                action(connection);
            } // typically Dispose will handle the closing
        }
    }
