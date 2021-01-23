        private void Form1_Load(object sender, EventArgs e)
        {
            // number of visitor
            int totalNumbers = 0;
            // Database
            string dbConStr = "Server=.\\sqlexpress;Database=Test;Integrated Security=true;";
             System.Data.SqlClient.SqlConnection sqlConnection1 = 
                new System.Data.SqlClient.SqlConnection(dbConStr);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT CounterTable (totalNumbers, day) VALUES (@totalNumbers, getdate())";
            cmd.Parameters.Add("totalNumbers",SqlDbType.Int).Value = totalNumbers;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }
