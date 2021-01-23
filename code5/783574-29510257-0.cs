    public static class ContentExtensions
    {                
        public static string RelativeUrl(this IContent content)
        {
            var pathParts = new List<string>();
            var n = content;
     
            while (n != null)
            {
                pathParts.Add(n.UrlName());
                n = n.Parent();                
            }
            pathParts.RemoveAt(pathParts.Count() - 1); //remove root node
            pathParts.Reverse();
            var path = "/" + string.Join("/", pathParts);
            return path;
        }    
     
        public static string UrlName(this IContent content)
        {
            return new DefaultUrlSegmentProvider().GetUrlSegment(content).ToLower();
        }     
    }
