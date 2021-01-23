    private void button1_Click(object sender, EventArgs e)
    {
        int amount;
        if(int.TryParse(textBox1.Text,out amount))
        {
            using (var com = new System.Data.SqlClient.SqlConnection("your connection string").CreateCommand())
            {
                com.CommandText = @"SELECT COUNT(WinNo01) AS CountOfball1
                                FROM tblLotto
                                GROUP BY WinNo01
                                HAVING WinNo01 = @num";
                com.Parameters.Add(new System.Data.SqlClient.SqlParameter("num", amount));
                com.Connection.Open();
                try
                {
                    int result = Convert.ToInt32(com.ExecuteScalar());
                    label2.Text = result.ToString();
                }
                finally 
                {
                    com.Connection.Close();
                }
            }
        }
    }
