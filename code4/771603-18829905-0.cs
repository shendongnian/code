    private void button1_Click(object sender, EventArgs e)
    {
        string kullaniciAdi; // user name
        string sifre; // password
    
        SqlConnection myConn = new SqlConnection();
        myConn.ConnectionString = "Data Source=localhost; database=EKS; uid=sa; pwd=123; connection lifetime=20; connection timeout=25; packet size=1024;";
        myConn.Open();
        try {
            SqlDataReader myReader;
            string myQuery = ("select u_password from [user] where u_name = @u_name");
            SqlCommand myCommand = new SqlCommand(myQuery,myConn);
            myCommand.Parameters.AddWithValue("@u_name", textBox1.Text);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                sifre = myReader["u_password"].ToString();
            }
        }
        catch (Exception x) {
            MessageBox.Show(x.ToString());
        }
        myConn.Close();
    
    }
