        public static string GetReferalUrl()
        {
            var lStrRefUrl = "";
            if (HttpContext.Current.Request.UrlReferrer != null)
                lStrRefUrl = HttpContext.Current.Request.UrlReferrer.Host;
            return lStrRefUrl;
        }
