    private static void Select()
        {
            try
            {
                Console.WriteLine(Environment.NewLine + "Start...");
                ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
                ConnectionStringSettings cs = settings["u2_connection"];
                U2Connection lConn = new U2Connection();
                lConn.ConnectionString = cs.ConnectionString;
                lConn.Open();
                Console.WriteLine("Connected...");
                U2Command cmd = lConn.CreateCommand();
                //ID,FNAME,LNAME : Single Value
                //SEMESTER: Multi Value
                //COURSE_NBR,COURSE_GRD: MS
                
                cmd.CommandText = string.Format("SELECT ID,FNAME,LNAME,SEMESTER,COURSE_NBR,COURSE_GRD FROM STUDENT WHERE ID > 0 ORDER BY ID");
                U2DataAdapter da = new U2DataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Console.WriteLine(Environment.NewLine);
                ds.WriteXml(Console.Out);
                lConn.Close();
                Console.WriteLine(Environment.NewLine + "End...");
                Console.WriteLine(SUCCESS_MSG);
                
            }
            catch (Exception e2)
            {
                string lErr = e2.Message;
                if (e2.InnerException != null)
                {
                    lErr += lErr + e2.InnerException.Message;
                }
                Console.WriteLine(Environment.NewLine + lErr);
                Console.WriteLine(FAIL_MSG);
            }
        }
