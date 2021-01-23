    private void button1_Click(object sender, EventArgs e)
    {
        string name = this.textBox1.Text;
        string connstring = @"....";
        string query = "Select * from diaryDB";
        using(SqlConnection con = new SqlConnection(connstring))
        using(SqlCommand com = new SqlCommand(query, con))
        {
            SqlParameter p = new SqlParameter("name", name);
            con.Open();
            using(SqlDataReader d =  com.ExecuteReader())
               deleteResult r = new deleteResult(d);
        }
        r.Show();
     }  
