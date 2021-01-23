       protected void Page_Load(object sender, EventArgs e)
       {
       if(!IsPostback)
       {
           txtUser.Text = Request.Form[txtUser.UniqueID];
           dropCountry.SelectedValue = Request.Form[dropCountry.UniqueID];
           dropVisa.SelectedValue = Request.Form[dropVisa.UniqueID];
           dropEntry.SelectedValue = Request.Form[dropEntry.UniqueID];
           txtDate.Text = Request.Form[txtDate.UniqueID];
       }
       }
