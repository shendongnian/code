     /// <summary>
        ///  Return true if successful SQL connection 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="timeout">timeout in msec</param>
        /// <returns></returns>
        public static bool QuickSQLConnectionTest(SqlConnection conn, int timeout)
        {
            // We'll use a Stopwatch here for simplicity. A comparison to a stored DateTime.Now value could also be used
            Stopwatch sw = new Stopwatch();
            bool connectSuccess = false;
            // Try to open the connection, if anything goes wrong, make sure we set connectSuccess = false
            Thread t = new Thread(delegate()
            {
                try
                {
                    sw.Start();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select Count(*) from Configuration", conn);
                    cmd.CommandTimeout = timeout/1000; // set command timeout to same as stopwatch period
                    cmd.ExecuteScalar();
                    connectSuccess = true;
                }
                catch (Exception Ex)
                {
                }
            });
            // Make sure it's marked as a background thread so it'll get cleaned up automatically
            t.IsBackground = true;
            t.Start();
            // Keep trying to join the thread until we either succeed or the timeout value has been exceeded
            while (timeout > sw.ElapsedMilliseconds)
                if (t.Join(1))
                    break;
            // If we didn't connect successfully
            if (!connectSuccess)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
