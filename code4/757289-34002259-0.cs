      public partial class Default2 : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCtr1"].ConnectionString);
        SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCtr2"].ConnectionString);
        ReportDocument rdoc = new ReportDocument();
        DataTable ds = new DataTable();
        DataTable ds1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
 
                loadreport();
                }
      private void loadreport()
    {
    {              
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *  from [MyTable1] where (Number LIKE '" + DropDownList1.Text + "') ", cn);
           da.Fill(ds);
           cn.Close();
    {
    {
           cn1.Open();
           SqlDataAdapter da1 = new SqlDataAdapter("select *  from [MyTable2] where (No LIKE '" + DropDownList1.Text + "') ", cn1);
                //DataTable ds1 = new DataTable();
            da1.Fill(ds1);
         cn1.Close();
    }
        rdoc.Database.Tables[0].SetDataSource(ds);
        rdoc.Database.Tables[1].SetDataSource(ds1);
       
        InvoiceReport.ReportSource = rdoc;
        InvoiceReport.DataBind();
    }
