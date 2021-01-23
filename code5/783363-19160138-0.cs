    namespace ConsoleApplication1
    {
        using System.Collections.Generic;
        using System.Linq;
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var result = new int[] { 1, 2, 3 }
                    .Select/* <int,int> */(Extensions.Test<int>)
                    .ToList();
            }
        }
        public static class Extensions
        {
            public static TReturnType Test<TReturnType>(int e)
            {
                return default(TReturnType);
            }
        }
    }
