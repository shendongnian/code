    public partial class chart3 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"connectionString");
            cmd = new SqlCommand("Select * from GraphChart",con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            Chart1.DataSource = source; 
            Chart1.Series[0].XValueMember = "Name";
            Chart1.Series[0].YValueMembers = "Age";
            Chart1.DataBind();
        }
    }
