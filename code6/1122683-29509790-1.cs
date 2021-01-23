    using System;
    using System.Collections.Generic;
    using System.Linq; 
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
 
    public partial class _Default : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
       {
           if (!Page.IsPostBack)
           {
              BindData();
           }
       }
       private void BindData()
       {
        string constr = "Data Source=Your Server;Database=Your DB;uid=User Name; pwd=Your Password;";
        string query = "SELECT PId, PName,Price FROM tblProducts";
        SqlDataAdapter da = new SqlDataAdapter(query, constr);
        DataTable table = new DataTable();
        da.Fill(table);
        ListView1.DataSource = table;
        ListView1.DataBind();
    }
     protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
     {
        ListView1.SelectedIndex = e.NewSelectedIndex;
        string pid = ListView1.SelectedDataKey.Value.ToString(); 
        MessageLabel.Text = "Selected Product ID: " + pid;
        BindData();
     }
    }
