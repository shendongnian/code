    public Guid SessionGUID(){
        if(HttpContext.Current.Request.Cookies["SessionGUID"])
        {
            //return the SessionGUID
            return HttpContext.Current.Request.Cookies["SessionGUID"].value as Guid;
        }
        else//new visit
        {
            //set cookie to a new random Guid
            var _guid=Guid.NewGuid();
            HttpCookie guidCookie = new HttpCookie("SessionGUID"); 
            guidCookie.Value = _guid;
            guidCookie.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(guidCookie);
            return _guid;
        } 
    }
