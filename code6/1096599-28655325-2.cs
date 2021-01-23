    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var list = new[] {2, 2, 2, 3, 3, 4, 4, 4, 4};
            var copy = list.ToArray();
            for (var i = 2; i < list.Length; i++)
            {
                if (list[i] == list[i - 1] && list[i] == list[i - 2])
                {
                    copy[i] = 0;
                    copy[i - 1] = 0;
                    copy[i - 2] = 0;
                }
            }
            foreach ( int item in copy )
                Console.Write(item);
        }
    }
