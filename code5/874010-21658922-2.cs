    using System;
    
    namespace BoxingTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i = 0;
                string s2 = ((object)i).ToString();
            }
        }
    }
