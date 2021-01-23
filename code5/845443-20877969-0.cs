    protected void Page_Load(object sender, EventArgs e)
    {
    string query="Data Source=Bun; user Id=sa; Password=sa; Initial Catalog=eBilling;";
            SqlConnection con = new SqlConnection(query);
            con.Open();
            string query1 = "select prodName from ProductMaster where @name='Bar Counter' ";
            SqlCommand cmd = new SqlCommand(query1, con);
    
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
    
                label1.Text = dr.GetValue(1).ToString();
                textBox1.Text = dr.GetValue(0).ToString();
    }
