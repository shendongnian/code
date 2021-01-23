     public DataTable DataTab(string query)
        {
            string conncetion = "Data Source=(local);Initial Catalog=Temp;User ID=sa;Password=sa123*";
            SqlConnection cnn = new SqlConnection(conncetion);
            string str = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
               
            DataTable dataTable = new DataTable(); 
            SqlDataAdapter adp = new SqlDataAdapter(query, cnn);
            adp.Fill(dataTable);
            return dataTable;
           
        }
