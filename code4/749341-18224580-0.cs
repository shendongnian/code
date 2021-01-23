    using System;
    using System.Collections.Generic;
    public class CustomComparer: IComparer<mymodel>
    {
        public int Compare(mymodel x, mymodel y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            // Add the comparison rules.
            // return 0 if are equal.
            // Return -1 if the second is greater.
            // Return 1 if the first is greater
        }
    }
