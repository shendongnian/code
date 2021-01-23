    protected void btnSaveCookie_Click(object sender, EventArgs e)
    {
        HttpCookie myCookie = new HttpCookie("userInfo");
        myCookie.Values["userName"] = "Patrick";
        myCookie.Values["lastVisit"] = DateTime.Now.ToString();
        Response.Cookies.Add(myCookie);
        Response.Write("Data Stored Into Cookie....");
    }
    
    protected void btnReadCookie_Click(object sender, EventArgs e)
    {
        HttpCookie readCookie = Request.Cookies.Get("userInfo");
    
        Response.Write("USERNAME: " + readCookie["userName"]);
        Response.Write("LAST VISIT: " + readCookie["lastVisit"]);
    }
