    class Program
    {
        static void Main(string[] args)
        {
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = "localhost";
            cs.Database = @"TESTDATABASE.FDB";
            cs.UserID = "SYSDBA";
            cs.Password = "masterkey";
            cs.Charset = "NONE";
            cs.Pooling = false;
    
            FbConnection connection = new FbConnection(cs.ToString());
            connection.Open();
    
            FbRemoteEvent revent = new FbRemoteEvent(connection);
            revent.AddEvents(new string[] { "new_order" });
    
            // Add callback to the Firebird events
            revent.RemoteEventCounts += new FbRemoteEventEventHandler(EventCounts);
    
            // Queue events
            revent.QueueEvents();
    
            string sql = "EXECUTE BLOCK AS BEGIN POST_EVENT 'new_order'; END";
    
            FbCommand command = new FbCommand(sql, connection);
    
            for (int i = 0; i < 5; i++)
            {
                command.ExecuteNonQuery();
            }
    
            System.Threading.Thread.Sleep(2000);
            connection.Close();
            Console.ReadLine();
        }
    
        static void EventCounts(object sender, FbRemoteEventEventArgs args)
        {
            Console.WriteLine("Event {0} has {1} counts.", args.Name, args.Counts);
        }
    }
