      [webmethod]
      public static ABC[] GetJSONdata(string id1)
            {
                MasterLogic ml = new MasterLogic();
                 DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string connStr = ConfigurationManager.ConnectionStrings["jsonobject"].ConnectionString;
        string cmdStr = "SELECT ([idd],[datetime],[col1],[col2],[col3]) FROM [jsondata] WHERE [idd]=@idd;";
        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@idd", id1);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                        dt = ds.Tables[0];
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
                List<ABC> ProjectStatus = new List<ABC>();
                foreach (DataRow dr in dt.Rows)
                {
                    ABC ps = new ABC();
                  ps.id=Convert.ToInt32(dr["Columnname"]);
                 // Do same To set value OF Properties
                    ProjectStatus.Add(ps);
    
                }
                return ProjectStatus.ToArray();
            }
