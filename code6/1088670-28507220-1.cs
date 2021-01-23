    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    using System.Data.SqlClient;
    public partial class _Default : System.Web.UI.Page
    {
    SqlConnection sqlCon = new   SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("Select * from tablename", sqlCon);
            sqlCon.Open();
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
    }
    protected void btnSearch_Click_Click(object sender, EventArgs e)
    {
        string Query = string.Empty;
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            if (DropDownList1.SelectedValue.ToString() == "Search By Employee Name")
            {
                Query = "select * from tablename where EmployeeName Like '%" + txtSearchName.Text + "%'";
            }
            else if (DropDownList1.SelectedValue.ToString() == "Search By Company Name")
            {
                Query = "select * from tablename where CompanyName Like '" + txtSearchName.Text + "%'";
            }
            else if (DropDownList1.SelectedValue.ToString() == "Search By Mobile")
            {
                Query = "select * from tablename where Mobile Like '%" + txtSearchName.Text + "'";
            }
            
            SqlDataAdapter sqlDa = new SqlDataAdapter(Query, sqlCon);
            DataSet Ds = new DataSet();
            sqlDa.Fill(Ds);
            GridView1.DataSource = Ds;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script>alert('wfrmGrid: 11')</script>" + ex.Message);
        }
        finally
        {
            sqlCon.Close();
        }
    }
}
