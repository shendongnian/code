    public static class HtmlHelperEx
    {
        public static string ToJson(this HtmlHelper html, object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
