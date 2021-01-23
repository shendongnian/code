    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace _29
    {
    
        public partial class Default : System.Web.UI.Page
        {
            
           
            private string strcon = WebConfigurationManager.ConnectionStrings["UserConnectionString1"].ConnectionString;
            protected void Page_Load(object sender, EventArgs e)
            {
                string p1 ="david";
                string p2 = "1234a";
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("Select count(UserName) from Users where UserName='" + p1 + "' and Password ='" + p2 + "'", con);
                con.Open();
                int result = (int)cmd.ExecuteScalar();
                Response.Write(result);
                
            }
    }
