    public void CheckLogin(object ses,bool ipb, Page page)
    {
        if (!(ses == null))
        {
            if (ses.ToString() == "Admin")
                page.MasterPageFile = "~/Admin.master";
            else
                page.MasterPageFile = "~/MasterPage.master";
        }
        else 
        {
            Response.Redirect("~/frmLogin.aspx");
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        checkLogin = new BLLcheckLogin();
        MasterPage mp;
        checkLogin.CheckLogin(Session["usertype"], IsPostBack, this);
    }
