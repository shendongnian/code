    private void button3_Click(object sender, EventArgs e)
        {
            string ssr;
            SqlConnection scr = new SqlConnection(@"Data Source=USER-PC\MSSQL;Initial Catalog=Highscore;Integrated Security=True");
            scr.Open();
            ssr = "Select Nume,Scor,DataInitiala,DataRecenta FROM Users where DataInitiala between @Param and @Param1 ";
            SqlCommand cmd2 = new SqlCommand(ssr, scr);
            cmd2.Parameters.AddWithValue("@Param", from.Text);
            cmd2.Parameters.AddWithValue("@Param1", to.Text);
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            adapter1.SelectCommand = cmd2;
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Refresh();         
        }
