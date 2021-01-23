    public static class ClearSQLiteCommandConnectionHelper
    {
        private static readonly List<SQLiteCommand> OpenCommands = new List<SQLiteCommand>();
        public static void Initialise()
        {
            SQLiteConnection.Changed += SqLiteConnectionOnChanged;
        }
   
        private static void SqLiteConnectionOnChanged(object sender, ConnectionEventArgs connectionEventArgs)
        {
            if (connectionEventArgs.EventType == SQLiteConnectionEventType.NewCommand && connectionEventArgs.Command is SQLiteCommand)
            {
                OpenCommands.Add((SQLiteCommand)connectionEventArgs.Command);
            }
            else if (connectionEventArgs.EventType == SQLiteConnectionEventType.DisposingCommand && connectionEventArgs.Command is SQLiteCommand)
            {
                OpenCommands.Remove((SQLiteCommand)connectionEventArgs.Command);
            }
            if (connectionEventArgs.EventType == SQLiteConnectionEventType.Closed)
            {
                var commands = OpenCommands.ToList();
                foreach (var cmd in commands)
                {
                    if (cmd.Connection == null)
                    {
                        OpenCommands.Remove(cmd);
                    }
                    else if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection = null;
                        OpenCommands.Remove(cmd);
                    }
                }
            }
        }
    }
