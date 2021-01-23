        if (Page.Header != null)
        {
            if (Page.Header.Title == null || !Page.Header.Title.Contains("COMPANYNAME"))
            {
                var otitle = Page.Header.Title;
                if (otitle == null || otitle.Length==0) {
                    var textinfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
                    otitle = textinfo.ToTitleCase(this.Parent.GetType().Name.Replace("_"," ").Replace("aspx",""));
                }
                Page.Header.Title = "COMPANYNAME" + " - " + otitle;
            }
            Page.Header.Title = Page.Header.Title.Replace("COMPANYNAME", Auth.getSetting("companyName"));
        }
