    public static class PageHelper
    {
        public static void SetThemeFromCookie(Page page)
        {
            HttpCookie c = Request.Cookies["theme"];
            page.Theme = c == null ? "Aqua" : c.Value;
        }
    }
