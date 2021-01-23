    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace UCDynamic
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            UCTest UCTest1;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    //Add UC
                    UCTest1 = (UCTest)Page.LoadControl("~/UCTest.ascx");
                    //Attach event
                    UCTest1.FirstNameChanged += FirstName_TextChanged;
    
                    this.Panel1.Controls.Add(UCTest1);
                }
            }
    
            protected void FirstName_TextChanged(string value)
            {
                TextBox1.Text = value;
    
                //Update value in database
            }
        }
    }
