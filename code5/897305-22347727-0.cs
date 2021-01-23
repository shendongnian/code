    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Web.SessionState;
    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //Onclick Submit Button
        [WebMethod(EnableSession = true)]
        //[System.Web.Services.WebMethod(EnableSession = true)]
        public static string Login(string email, string password)
        {
            var con = ConfigurationManager.ConnectionStrings["blogConnString"].ConnectionString;
            con.Open();
            string res = "0";
            SqlDataReader reader;       
            string sql = "select uid,username from personal where email=@Email and password=@Password;
            using(SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@Email", SqlDbType.String);
                command.Parameters["@Email"].Value = email;
                command.Parameters.AddWithValue("@Password", password);       
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                   res = "1";
                   HttpContext.Current.Session["UID"] = reader["uid"].ToString();           //Either Remove Static from Method Declaration or use HttpContext.Current along with session.
                   HttpContext.Current.Session["UNAME"] = reader["username"].ToString();
                }
            }
            return res;
            con.Close();
        }
    }
