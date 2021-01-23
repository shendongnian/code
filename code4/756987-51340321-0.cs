    using System;  
    using System.Data.SqlClient;  
    using System.Configuration;  
    public partial class _Default: System.Web.UI.Page {  
        protected void Page_Load(object sender, EventArgs e) {  
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;  
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);  
            con.Open();  
        }  
    }  
