        string connectionString =   "user id=USERNAME;" +
                                    "server=SERVERNAME;" +
                                    "Trusted_Connection=yes;" +
                                    "database=claytonDatabase; " +
                                    "connection timeout=30";
        string Get_Data = "SELECT * FROM dbo.location";
        try
        {
            using(SqlConnection thisConnection = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand(Get_Data, thisConnection))
            using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                thisConnection.Open();
                DataTable dt = new DataTable("locationTable");
                sda.Fill(dt); 
                foreach (DataRow dataRow in dt.Rows)
                {
                     foreach (var item in dataRow.ItemArray)
                     {
                        Console.WriteLine(item);
                     }
                }
           }
       }
       catch(Exception ex)
       {
            MessageBox.Show("db error " + ex.Message);
       }   
