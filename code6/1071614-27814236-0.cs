    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace Testing
    {
        public partial class WebForm59 : System.Web.UI.Page
        {
            Boolean IsPageRefresh;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ViewState["postids"] = System.Guid.NewGuid().ToString();
                    Session["postid"] = ViewState["postids"].ToString();
                }
                else
                {
                    if (ViewState["postids"].ToString() != Session["postid"].ToString())
                    {
                        IsPageRefresh = true;
                    }
                    Session["postid"] = System.Guid.NewGuid().ToString();
                    ViewState["postids"] = Session["postid"].ToString();
                }
            }
            protected void submitBtn_Click(object sender, EventArgs e)
            {
                if (IsPageRefresh) textIn.Value = " refresh";
                else textIn.Value = "not refresh";
            }
        }
    }
