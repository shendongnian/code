    ServerConnection connection = new ServerConnection(serverName, userName, password);
    Server sqlServer = new Server(connection);
    MessageBox.Show("Server Status: "
                + sqlServer.Status
                + "\r\nDatabase Name: "
                + sqlConn.Database + " Active Connections: "
                + sqlServer.GetActiveDBConnectionCount(sqlConn.Database));
    Restore rstDatabase = new Restore();
    rstDatabase.Action = RestoreActionType.Database;
    rstDatabase.Database = databaseName;
    BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
    rstDatabase.Devices.Add(bkpDevice);
    rstDatabase.ReplaceDatabase = true;
    rstDatabase.SqlRestore(sqlServer);
