    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    public partial class WebPages_database : System.Web.UI.Page
      {
   
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETConnectionString"].ToString());
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnAdmnNumber_Click(object sender, EventArgs e)
    {
        string qry = "select * from Table";
        da = new SqlDataAdapter(qry, con);
        ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
