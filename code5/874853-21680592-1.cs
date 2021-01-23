    public static HtmlString Pdf(this UrlHelper helper, string fileName, string directory)
    {
        string _fileName = fileName + ".pdf";
        string _directory = directory + "/";
        string root = "~/Content/Templates/";
        string path = HttpContext.Current.Server.MapPath(root + _directory + _fileName);
        if (File.Exists(path))
        {
            return new HtmlString(helper.Content("<a href=\"" + root.Replace("~", "") + _directory + _fileName + "\" target=\"_blank\">Download Template</a>"));
        }
        else
        {
            return new HtmlString("");
        }            
    }
