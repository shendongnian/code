    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace MyNameSpace
    {
        public class MyComparer: IComparer<int>
        {
            public int Compare(int x, int y)
            {
                // x is greater move it up
                if (x > y)
                {
                    return 1;
                }
                
                // x is smaller move y up
                if (x < y)
                {
                    return -1;
                }
                
                // do nothing (equal)
                return 0;
            }
        }
    }
