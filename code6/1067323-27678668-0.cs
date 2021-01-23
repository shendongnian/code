    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using MySql;
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            private string _connectionString;
            protected void Page_Load(object sender, EventArgs e)
            {
                _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Webappconstring"].ToString();
            }
            protected void Clicked(object sender, EventArgs e)
            {
                string email = Emailtxt.Text;
                string password = passwordtxt.Text;
                var mysqlAccess = new MySqlAccess(_connectionString);
                string status = mysqlAccess.GetStatus(email, password);
            
                if (status == Constants.Status.PRESIDENT || status == Constants.Status.FACULTY_MEMBER)
                {
                    Session["Email"] = email;
                    Response.Redirect("WebForm2.aspx", true);
                }
                else
                {
                    Emailtxt.Text = "invalid user";
                }
            }
        }
        internal class MySqlAccess
        {
            private readonly string _connectionString;
            public MySqlAccess(string connectionString)
            {
                _connectionString = connectionString;
            }
            public string GetStatus(string email, string password)
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT Status FROM the_society_circle.society WHERE Email=@Email AND Psswd=@Password;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                return reader["Status"].ToString();
                            }
                        }
                    }
                }
                return string.Empty;
            }
        }
        internal class Constants
        {
            internal class Status
            {
                public const string PRESIDENT = "president";
                public const string FACULTY_MEMBER = "faculty member";
            }
        }
    }
