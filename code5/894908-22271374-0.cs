    protected void btnSubmitAd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Ads ad = new Ads
            {
                Title = txtAdTitle.Text,
                Dec = txtAdText.Text,
                Name = txtName.Text,
                Email = txtEmail.Text
            };
            context.Ads.Add(ad);
            context.SaveChanges();
            //MultiView1.SetActiveView(View2);  No need for that as it will be lost after redirect... 
            //Append your ActiveView information in query string with Request.Url.AbsoluteUri
            Response.Redirect(Request.Url.AbsoluteUri + "?activeView=View2");// 
         }
    }
