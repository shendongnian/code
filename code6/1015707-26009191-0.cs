    public partial class chartDummy : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"ConnectionString");
            cmd = new SqlCommand("Select Mains_Run_Hrs, DG_Run_Auto_Mode, Battery_Run_Hrs, Solar_Run_hrs from tbl_runtime_report", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
                Chart1.DataSource = ds;
                Chart1.Series[0].YValueMembers = "Mains_Run_Hrs";
                Chart1.Series[0].XValueMember = "DG_Run_Auto_Mode";
                Chart1.Series[0].XValueMember = "Battery_Run_Hrs";
                Chart1.Series[0].XValueMember = "Solar_Run_hrs";
                Chart1.DataBind();
    
        }   
    }
