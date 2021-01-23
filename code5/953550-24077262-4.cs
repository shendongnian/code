    using System;
    using System.Collections.Generic;
    using System.Linq;
    using s = System.String;
    using sc = System.StringComparison;
    using l = System.Collections.Generic.List<Test.Test.c>;
    
    namespace Test
    {
        class Test
        {
            private sc cic = sc.InvariantCultureIgnoreCase;
    
            public class c
            {
                public s i;
            }
    
            private void Test(s i)
            {
                l ml = new l();
    
                ml.FirstOrDefault(
                    c => s.Equals(
                             c.i, 
                             i,
                             cic));
            }
        }
    }
:-)
