    /// <summary>
    /// Sets cookie.
    /// </summary>
    /// <param name="cookieName">Cookie name</param>
    /// <param name="cookieValue">Cookie value</param>
    /// <param name="days">Days to be expired</param>
    public static void SetCookie(string cookieName, string cookieValue, int days)
    {
        try
        {
            var dt = DateTime.Now;
    
            var cookie = new HttpCookie(cookieName);
            cookie.Value = cookieValue;
            cookie.Expires = dt.AddDays(days);
    
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        catch (Exception ex)
        {
            // Log error
        }
    }
    
    /// <summary>
    /// Gets cookie string
    /// </summary>
    /// <param name="cookieName">Cookie name</param>
    /// <returns>Cookie string</returns>
    public static String GetCookie(String cookieName)
    {
        try
        {
            if (HttpContext.Current.Request.Cookies[cookieName] == null)
                return String.Empty;
    
            return HttpContext.Current.Request.Cookies[cookieName].Value;
        }
        catch (Exception ex)
        {
            // Log error
            return String.Empty;
        }
    }
