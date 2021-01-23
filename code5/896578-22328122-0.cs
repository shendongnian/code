    protected void Page_Load(object sender, EventArgs e)
        {
            // on every "first" page load which is also every refresh through meta refresh tag
            // this one will not be executed when we click checkbox which is a true postback
            if (!IsPostBack)
            {
                Response.Write("Refreshed! " + DateTime.Now);
                AutoRefreshSite();
            }
        }
    
        protected void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            // store value into session
            Session["autorefresh"] = chkAutoRefresh.Checked;
            // call method where you enable/disable auto refresh
            AutoRefreshSite();
        }
    
        protected void AutoRefreshSite()
        {
            if (Session["autorefresh"] != null)
            {
                // append meta refresh tag
                if (bool.Parse(Session["autorefresh"].ToString()))
                {
                    HtmlMeta tag = new HtmlMeta();
                    tag.HttpEquiv = "refresh";
                    tag.Content = "5";
                    Header.Controls.Add(tag);
                    chkAutoRefresh.Checked = true;
                }
            }
        }
 
