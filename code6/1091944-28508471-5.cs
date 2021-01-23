    if (Request.Cookies["TestCookieValue"] != null)
    {
        ViewBag.CookieValue = Request.Cookies["TestCookieValue"].DecodedValue();
    }
    if (Request.Cookies["TestCookieValues"] != null)
    {
        ViewBag.CookieValues = Request.Cookies["TestCookieValues"].DecodedValues("foo");
        ViewBag.CookieValuesIndexed = Request.Cookies["TestCookieValues"].DecodedValues(0);
    }
    var cookieWithValue = new HttpCookie("TestCookieValue");
    cookieWithValue.Expires = DateTime.Now.AddHours(1);
    cookieWithValue.SetEncodedValue("Inglês");
    Response.SetCookie(cookieWithValue);
    var cookieWithValues = new HttpCookie("TestCookieValues");
    cookieWithValues.Expires = DateTime.Now.AddHours(1);
    cookieWithValues.SetEncodedValues("foo", "Inglês");
    Response.SetCookie(cookieWithValues);
