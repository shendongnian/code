    i found an answer to my question which i posted some days back.......hope this is useful  to anybody who is new to ...
    
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
            LinkButton[] linkBtn;
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
                if (Session["objLinkBtn"] != null)
                {
                    linkBtn = (LinkButton[])Session["objLinkBtn"];
                    for (int i = 0; i < linkBtn.Length; i++)
                    {
                        linkBtn[i] = new LinkButton();
                        linkBtn[i].Text = "Link" + (i + 1);
                        linkBtn[i].Click += new EventHandler(WebForm1_Click);
                        pnlLinks.Controls.Add(linkBtn[i]);
                    }
                    Session["objLinkBtn"] = linkBtn;
                }
            }
    
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                int x;
    
    
                if (int.TryParse(txtNumber.Text, out x))
                {
                    linkBtn = new LinkButton[x];
                    for (int i = 0; i < x; i++)
                    {
                        linkBtn[i] = new LinkButton();
                        linkBtn[i].Text = "Link" + (i + 1);
                        linkBtn[i].Click += new EventHandler(WebForm1_Click);
                        pnlLinks.Controls.Add(linkBtn[i]);
                    }
                    Session["objLinkBtn"] = linkBtn;
                }
            }
    
            void WebForm1_Click(object sender, EventArgs e)
            {
                LinkButton btn = (LinkButton)sender;
                int ctrlNo = int.Parse(btn.Text.Replace("Link", ""));
    
                switch (ctrlNo)
                {
                    case 1: Response.Redirect("http://www.google.com"); break;
                    case 2: Response.Redirect("http://www.gmail.com"); break;
                    case 3: Response.Redirect("http://www.youtube.com"); break;
                    default: Response.Redirect("http://www.facebook.com"); break;
                }
            }
        }
    }
    
     
    
