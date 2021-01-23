    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 11; i++)
            {
                LinkButton linkButton = new LinkButton();
                linkButton.Text = "Lnk" + i;
                linkButton.Click += linkButton_Click;
                form1.Controls.Add(linkButton);
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerText = "Separator";
                form1.Controls.Add(p);
            }
        }
        void linkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.stackoverflow.com");
        }
    }
