    using System;
    using System.IO;
    
    namespace Namespace
    {
        class StringCastBase
        {
            public static explicit operator string(StringCastBase o)
            {
                return "string cast base";
            }
        }
    
        class StringCastDerived : StringCastBase
        {
            public static explicit operator string(StringCastDerived o)
            {
                return "string cast derived";
            }
        }
    
        class ToStringOverridenBase
        {
            public override string ToString()
            {
                return "ToString overriden base";
            }
        }
    
        class ToStringOverridenDerived : ToStringOverridenBase
        {
            public override string ToString()
            {
                return "ToString overriden derived";
            }
        }
    
        class Programm
        {
            public static void Main()
            {
                StringCastBase scb = new StringCastBase();
                Console.WriteLine((string)scb);
    
                StringCastBase scd = new StringCastDerived();
                Console.WriteLine((string)scd);
    
                ToStringOverridenBase tsob = new ToStringOverridenBase();
                Console.WriteLine(tsob);
    
                ToStringOverridenBase tsod = new ToStringOverridenDerived();
                Console.WriteLine(tsod);
            }
        }
    }
