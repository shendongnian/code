    using System.Data;
    using System.Data.SqlClient;
    using CrystalDecisions.CrystalReports.Engine;
    
    public partial class Student_Report : System.Web.UI.Page
    {
        SqlConnection cn;
        // SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            cn = new SqlConnection(str);
            cn.Open();
            da = new SqlDataAdapter("select * from StudentReg_mst", cn);
            ds = new DataSet();
            da.Fill(ds, "StudentReg_mst");
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("StudentReport.rpt"));
            rd.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();
        }
