    if(User.IsInRole("Admin"))
    {
        var ulMenu  = (HtmlGenericControl)Page.FindControl("ul_myLst");
        var liAdmin = new HtmlGenericControl("li");
        var a = new HtmlAnchor();
        a.HRef = "OurFaculty.aspx";
        a.InnerText = "Admin";
        liAdmin.Controls.Add(a);
        ulMenu.Controls.Add(liAdmin);
    }
