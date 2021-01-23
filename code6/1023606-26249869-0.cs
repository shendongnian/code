            const string connectionString =
                 @"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0 XML;Data Source=C:\source\MyExcel.xlsx;";
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                foreach (var sheet in new[] { "sheet1", "sheet2", "sheet3" })
                {
                    using (var cmd = new OleDbCommand())
                    {
                        cmd.Connection = conn;
                        try
                        {
                            cmd.CommandText = "CREATE TABLE [" + sheet + "] (id INT, datecol DATE );";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception) // TODO: find better way to determine existing sheet
                        {
                            Console.WriteLine("Can't create {0}", sheet);
                        }
                    }
                    for (var i = 0; i < 1000; i++)
                    {
                        using (var cmd = new OleDbCommand())
                        {
                            cmd.Connection = conn;
                            var datecol = DateTime.Now;
                            var id =  i;
                            cmd.CommandText = "INSERT INTO [" + sheet + "](id, datecol) VALUES(@id,@datecol);";
                            cmd.Parameters.Add("@id", OleDbType.Integer).Value = id;
                            cmd.Parameters.Add("@datecol", OleDbType.Date).Value = datecol;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                conn.Close();
            }
