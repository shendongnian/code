    protected void Page_Load(object sender, EventArgs e)
                {
    //get the session variable from the open page in order to do the search.
                    if (Session["CustTypeVal"] != null)
                    {
                        //The method you need to run after refresh
                        SearchInvAddr((string)Session["CustTypeVal"]);
                        //Remove the session after
                        Session.Remove("CustTypeVal");
                    }
    }
