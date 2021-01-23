    internal string sid {
        get {
            HttpCookie htk = HttpContext.Request.Cookies["sid"];
            if(htk == null) {
                htk = HttpContext.Response.Cookies["sid"];
            }
            return htk == null ? null : htk.Value;
        }
    }
