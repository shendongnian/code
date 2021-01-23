    using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Data.SqlClient;
        using System.Configuration;
        using System.Data;
        using System.Web.Security;
        using System.Globalization;
        using System.Text;
        using System.Threading;
        
        public partial class register : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
        
            }
            protected void btnCreate_Click(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sacpConnectionString"].ConnectionString))
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            Guid guid;
                            guid = Guid.NewGuid();
                            string sql = @"UPDATE patient 
                                SET 
                                pUserName = @pUserName,
                                pPassword = @pPassword
                                WHERE pIC = @pIC";
        
                            cmd.Parameters.AddWithValue("@pIC", txtIC.Value);
                            cmd.Parameters.AddWithValue("@pUsername", txtUsername.Value);
                            cmd.Parameters.AddWithValue("@pPassword", txtPassword.Value);
        
                            cmd.Connection = con;
                            cmd.CommandText = sql;
                            
                            con.Open();
        
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "SELECT patientID, pUsername, pPassword FROM patient WHERE pIC = @pIC;";
        
                            int id = (cmd.ExecuteScalar() != null) ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
                            if (id > 0)
                            {
        
                                Session.Add("ID", id);
        
                                Session.Add("Username", txtUsername.Value);
                                Session.Add("Password", txtPassword.Value);
                                FormsAuthentication.SetAuthCookie(txtUsername.Value, true);
                                Response.Redirect("registered.aspx");
                            }
        
                        }
        
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
        }
