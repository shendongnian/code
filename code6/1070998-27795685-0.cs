    protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack) //just write this
                    return;
        
            if (Session["User"] != null)
            {
                RegisterRelated.Visible = false;
                LoginRelated.Visible = false;
                InPage.Visible = true;
                WelcomeTag.Text = "Welcome, " + ((User)Session["User"]).Username + ".";
            }
            else
            {
                RegisterRelated.Visible = true;
                LoginRelated.Visible = true;
                WelcomeTag.Text = String.Empty;
                InPage.Visible = false;
            }
        }
