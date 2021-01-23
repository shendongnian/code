    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApp.PopupAdd
    {
        public partial class popup : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                var sql = "insert into students (studentname) values (@name)";
                SqlConnection cxn = new SqlConnection();
                cxn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["ConnectionString"].ConnectionString;
                var cmd = cxn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();
                ClientScript.RegisterStartupScript(this.GetType(),"update", "update()", true);
            }
        }
    }
