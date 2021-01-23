    private static void Update_Using_DataSet()
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
                cmd.CommandText = string.Format("SELECT ID,FNAME,LNAME,SEMESTER,COURSE_NBR,COURSE_GRD FROM STUDENT WHERE ID={0} ORDER BY ID",ID);
                U2DataAdapter da = new U2DataAdapter(cmd);
                U2CommandBuilder builder = new U2CommandBuilder(da);
                da.UpdateCommand = builder.GetUpdateCommand();
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRowCollection lDataRowCollection = dt.Rows;
                int i = 1;
                foreach (DataRow item in lDataRowCollection)
                {
                    item["FNAME"] = item["FNAME"] + "3";// modify single value
                    item["SEMESTER"] = item["SEMESTER"] + "$";//modify multi-value
                    item["COURSE_GRD"] = item["COURSE_GRD"] + "$";
                    i++;
                }
                da.Update(ds);//use DataAdapter's Update() API
                //print modified value
                cmd.CommandText = string.Format("SELECT ID,FNAME,LNAME,SEMESTER,COURSE_NBR,COURSE_GRD FROM STUDENT WHERE ID={0} ORDER BY ID", ID); ;
                
                //verify the change
                U2DataAdapter da2 = new U2DataAdapter(cmd);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                Console.WriteLine(Environment.NewLine);
                ds2.WriteXml(Console.Out);
                //close connection
                lConn.Close();
                Console.WriteLine(Environment.NewLine + "End...");
                Console.WriteLine(SUCCESS_MSG);
            }
            catch (Exception e2)
            {
                Console.WriteLine(FAIL_MSG);
                string lErr = e2.Message;
                if (e2.InnerException != null)
                {
                    lErr += lErr + e2.InnerException.Message;
                }
                Console.WriteLine(Environment.NewLine + lErr);
            }
        }
