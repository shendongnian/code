    public static class MyExtensions
    {
         public static IEnumerable<XElement> MyAncestorsAndSelf(this IEnumerable<XElement> source, XName name)
         {
             if(name == null)
             {
                 return source.AncestorsAndSelf();
             }
             return source.AncestorsAndSelf(name);
         }
    }
