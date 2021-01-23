    if ( Request.Cookies["MyCookie"] != null )
    {
        var c = new HttpCookie( "MyCookie" );
        c.Expires = DateTime.Now.AddDays( -1 );
        Response.Cookies.Add( c );
    }
