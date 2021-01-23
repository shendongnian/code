            //fill the datatable from back end
            string connStr = ConfigurationManager.ConnectionStrings["ConsoleApplication1.Properties.Settings.NORTHWNDConnectionString"].ConnectionString;            
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand comm = new SqlCommand("select categoryid,categoryname from Categories order by categoryname");            
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            DataTable dt = new DataTable();           
            dt.Load(dr);
            //datatable filter logic
            string[] filter = { "1", "2" };
            
            
            DataTable filteredTable =   dt.Clone();
            foreach (string str in filter)
            {
                DataRow[] filteredRows = dt.Select("categoryid="+ str); //search for categoryID
                foreach (DataRow dtr in filteredRows)
                {
                    filteredTable.ImportRow(dtr);
                }                
                
            }
