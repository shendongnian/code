    protected void btnSaveCookie_Click(object sender, EventArgs e)
    {
        SetCookie("userName", "Patrick", 1); // Save for one day
        SetCookie("lastVisit", DateTime.Now.ToString(), 1);
    }
    
    protected void btnReadCookie_Click(object sender, EventArgs e)
    {
        Response.Write("USERNAME: " + GetCookie("userName"));
        Response.Write("LAST VISIT: " + GetCookie("lastVisit"));
    }
