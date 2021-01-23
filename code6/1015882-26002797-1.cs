    protected void toggle_lang(object sender, DirectEventArgs e)
        {
            if (Culture.ToString() == "English (Canada)")
            {
                HttpCookie cookie = new HttpCookie("CurrentLanguage");
                cookie.Value = "fr-CA";
               Response.SetCookie(cookie);
               Response.Redirect(Request.RawUrl);
            }
            else 
            {
                HttpCookie cookie = new HttpCookie("CurrentLanguage");
                cookie.Value = "en-CA";
                Response.SetCookie(cookie);
                Response.Redirect(Request.RawUrl);
            }
            
        }
