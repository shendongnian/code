            //For exemple: /en/Default.aspx
            string currentURL = HttpContext.Current.Request.Url.AbsolutePath;
            //Manage different part of the URL
            string[] urlParts = currentURL.Split(new string[] {"/"},StringSplitOptions.RemoveEmptyEntries);
            //Remove the old culture code
            IEnumerable<string> invariantUrlParts = urlParts.Skip(1);
            //Rebuild the URL
            string newUrl = String.Format("~/{0}/{1}", "fr", String.Join("/", invariantUrlParts));
            //Redirect to ~/fr/Default.aspx
            Response.Redirect(newUrl);
