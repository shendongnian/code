    public string GetData(int value)
    {
        var reply = string.Join(", ", 
                        from x in HttpContext.Current.Request.Cookies.AllKeys 
                        select x + "=" + HttpContext.Current.Request.Cookies[x].Value);
        HttpContext.Current.Response.Cookies.Add(new HttpCookie("Test", "Test123"));
        HttpContext.Current.Response.Cookies.Add(new HttpCookie("Test2", "Test1234"));
        return reply;
    }
