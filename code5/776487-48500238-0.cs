     protected void Page_Load(object sender, EventArgs e)
    {
        using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Table1", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            conn.Close();
        }
    }
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
