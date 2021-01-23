    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace saxerium
    {
    class Program
    {
        static void Main(string[] args)
        {
            int ix = 10;
            unsafe
            {
                int* px1;
                int* px2 = &ix;
                Test.F(out px1, ref px2);
                Console.WriteLine("*px1 = {0}, *px2 = {1}",
                   *px1, *px2);   // undefined behavior
            }
        }
    }
    class Test
    {
        static int value = 20;
        public unsafe static void F(out int* pi1, ref int* pi2)
        {
            int i = 10;
            pi1 = &i;
            fixed (int* pj = &value)
            {
                // ...
                pi2 = pj;
            }
        }
    }
}
