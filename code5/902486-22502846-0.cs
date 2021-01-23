    private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
    {
            SqlConnection con = new SqlConnection(@"Data Source=YourSERVER;Initial Catalog=YourDataBaseName;User ID=DBUserName;Password=DBPassword");
            SqlCommand com = new SqlCommand("select top 1 * from yourTable where someCondition=true",con);
            SqlDataAdapter adp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtReference.Text = dt.Rows[0]["refrence_no"].ToString();
    }
