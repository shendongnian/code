    public static class ImageHelper
    {
        public static Image LoadFromAspNetUrl(string url)
        {
            if(HttpContext.Current == null)
            {
                throw new ApplicationException("Can't use HttpContext.Current in non-ASP.NET context");
            }
            return Image.FromFile(HttpContext.Current.Server.MapPath(url));
        }
    }
