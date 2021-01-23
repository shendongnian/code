    using System.Collections.Generic;
    using System.Linq;
    
    namespace SortTest
    {
        class Program
        {
            public static IEnumerable<T> Sort<T>(IEnumerable<T> list) where T : BaseType
            {
                return list.OrderByDescending(a => a.SortOrder);
            }
    
            static void Main(string[] args)
            {
    
                List<Type1> theList = new List<Type1>();
                for (int i = 0; i < 10; i++)
                {
                    theList.Add(new Type1() { SortOrder = i });
                }
    
                theList = Sort(theList).ToList();
    
            }
        }
    
        public class BaseType { public int SortOrder { get; set; } }
        public class Type1 : BaseType { }
    }
