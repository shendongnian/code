    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Data.SqlClient;
    
    public partial class ForumPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
    
    
    
            string t = "TPost";
            string f = "PostTitle,PostQuestion";
            string v = "@pt,@pq";
    
            lib.insert(t, f, v);
            lib.cmd.Parameters.AddWithValue("@pt", this.tbxTitle.Text);
            lib.cmd.Parameters.AddWithValue("@pq", this.tbxText.Text);
            lib.con.Open();
            lib.cmd.ExecuteNonQuery();
            lib.con.Close();
    
            lblshow.Text = "submited !!!";
    
    
        }
    }
