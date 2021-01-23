    using(MySqlConnection cnn = new MySqlConnection(..put a connstring here...))
    using(MySqlCommand cmd = cnn.CreateCommand())
    {
        cnn.Open();
        cmd.CommandText = @"INSERT INTO devices 
                          (Names, DeviceIP, DoesBackup, DeviceType, LastBackup)
                          VALUES (@name, @ip, @backs, @type, @last)
                          ON DUPLICATE KEY UPDATE LastBackup=@last";
        cmd.Parameters.AddWithValue("@name", variableWithDeviceNameValue);
        cmd.Parameters.AddWithValue("@ip", variableWithIPValue);
        cmd.Parameters.AddWithValue("@backs", variableWithDoesBackupValue);
        cmd.Parameters.AddWithValue("@type", variableWithDeviceTypeValue);
        cmd.Parameters.AddWithValue("@last", variableWithLastBackupValue);
        cmd.ExecuteNonQuery();
    }
