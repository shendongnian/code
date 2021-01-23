    using System;
    
    namespace Bad
    {
        class Students {}
        
        class Test
        {
            static void Main()
            {
                object o = new Good.Students();
                Students cast = (Students) o;
            }
        }
    }
    
    namespace Good
    {
        class Students {}
    }
