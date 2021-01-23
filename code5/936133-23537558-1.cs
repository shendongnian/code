     public class person
        {
            public string name { get; set; }
            public int age { get; set; }
        }
===================================================================
     public static class ListExtensions
        {
            public static List<T> AddObject<T>(this List<T> lst)
            {
                var a = default(T);
                lst.Add(a);
                return lst;
            }
        }
