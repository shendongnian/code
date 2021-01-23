    public static class Helpers
    {
        public static MvcHtmlString GetStructure(int size)
        {
            return MvcHtmlString.Create(GetRecursiveStructure(size));
        }
        private static string GetRecursiveStructure(int size)
        {
            if (size == 0)
            {
                return "";
            }
            else
            {
                TagBuilder topTag = new TagBuilder("div");
                topTag.AddCssClass(string.Format("round-{0}-top", size));
                topTag.InnerHtml = GetRecursiveStructure(size - 1);
                TagBuilder bottomTag = new TagBuilder("div");
                bottomTag.AddCssClass(string.Format("round-{0}-bottom", size));
                bottomTag.InnerHtml = GetRecursiveStructure(size - 1);
                return topTag.ToString() + bottomTag.ToString();
            }
        }
    }
