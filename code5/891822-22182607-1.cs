    public static class ContextHelper
    {
        public static HttpContextBase GetHttpContextBase()
        {
            return new HttpContextWrapper(HttpContext.Current);
        }
    }
