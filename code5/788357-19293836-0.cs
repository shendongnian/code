    protected void lnkCheckOut_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            //lnkCheckOut.PostBackUrl = "~/checkout.aspx?type=checkout";
           Session["IsQuoteAdded"] = "false";
            Response.Redirect(@"~/checkout.aspx?type=checkout");
        }
        //if not logged in user
        else
        {
           Response.Redirect(@"~/login.aspx?returnUrl="+HttpUtility.UrlEncode(Request.RawUrl));
        }
    }
