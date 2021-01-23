    protected void Page_Load(object sender, EventArgs e)
    {
            ConectionStrings cs = new ConectionStrings();
            SqlConnection con = new SqlConnection(cs.Db);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Library order by mem_id", con);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);
            tb.AcceptChanges();
            GridView_all_records.DataSource = tb;
            GridView_all_records.DataBind();
            con.Close();
       
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Admin Login.aspx");
    }
}
