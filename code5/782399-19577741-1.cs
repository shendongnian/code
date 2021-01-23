            using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Data.SqlClient;
        using System.Data;
        using System.Drawing;
        using System.Configuration;
        namespace ModalPopupExtenderAJAXToolkitWebApp
        {
            public partial class _Default : System.Web.UI.Page
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
                protected void Page_Load(object sender, EventArgs e)
                {
                    if (!IsPostBack)
                    {
                        BindGridData();
                    }
                }
        
                protected void BindGridData()
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Select * from Employee_Details", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        UpdatePanel1.Update();
                    }
                }
                protected DataTable SearchDetails(string id)
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Select * from Employee_Details where UserId=@UserId", con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@UserId",Convert.ToInt32(id)));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    return dt;
                }
                protected void imgSearch_Click(object sender, EventArgs e)
                {
                    string id = txtSearch.Text;
                    if (id != null)
                    {
                        DataTable dt = new DataTable();
                        dt = SearchDetails(id);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        UpdatePanel1.Update();
                        this.ModalPopupExtender2.Show();
                    }
                }
        
            }
        }
