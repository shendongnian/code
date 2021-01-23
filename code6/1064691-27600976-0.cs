    private void button1_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        SqlConnection objConn = new SqlConnection(strConnString);
        string strSQL = "SELECT * FROM ADMS_Machining ";
        SqlDataAdapter sda = new SqlDataAdapter(strSQL, objConn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
