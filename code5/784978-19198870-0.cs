    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["X"] != null)
            {
                Response.Redirect("MemberPage.aspx");
            }
        }
    
        SqlConnection cnn = new SqlConnection("Initial Catalog=Northwind;Data Source=localhost;Integrated Security=SSPI;");
    
        protected void Button1_Click(object sender, EventArgs e)
        {
    
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT FirstName,LastName FROM Employees", cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                
                    if (TextBox1.Text.Trim() == dr.GetString(0) || TextBox2.Text.Trim()== dr.GetString(1))
                        {
                            if (TextBox2.Text.Trim()== dr.GetString(1))
                            {
                                Session["x"] = TextBox1.Text.Trim();
                                Response.Redirect("MemberPage.aspx");
                            }
                            else
                            {
                                Label2.Text = "wrong password";
                            }
                        }
                    else
                    {
                        Label2.Text = "wrong login";
                    }
                
            }
    
            cnn.Close();
    
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
