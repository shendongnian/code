        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
         
        namespace WebApplication1
        {
            public partial class WebForm1 : System.Web.UI.Page
            {
                protected void Page_Load(object sender, EventArgs e)
                {
                }
         
                protected void btnSearch_Click(object sender, EventArgs e)
                {
                    string lastName = txtLastName.Text.Trim();
                    string speciality = ddlSpeciality.Text;
                    string location = ddlLocation.Text;
                    Response.Redirect(string.Format("page2.aspx?lastname={0}&speciality={1}&location={2}",lastName ,speciality , location));
         
        
                }
            }
         
        
        }
        
