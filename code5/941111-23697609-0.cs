		string cs = @"server=localhost;userid=user12;
            password=34klq*;database=mydb";
        MySqlConnection conn = null;
        try 
        {
            conn = new MySqlConnection(cs);
            conn.Open();
            string stm = "SELECT * FROM Authors";
            MySqlDataAdapter da = new MySqlDataAdapter(stm, conn);
            DataSet ds = new DataSet();
            
            da.Fill(ds, "Authors");
            DataTable dt = ds.Tables["Authors"];
            dt.WriteXml("authors.xml");
            foreach (DataRow row in dt.Rows) 
            {            
                foreach (DataColumn col in dt.Columns) 
                {
                  Console.WriteLine(row[col]);
                }
                
                Console.WriteLine("".PadLeft(20, '='));
            }
        } catch (MySqlException ex) 
        {
            Console.WriteLine("Error: {0}",  ex.ToString());
        } finally 
        {          
            if (conn != null) 
            {
                conn.Close();
            }
        }
