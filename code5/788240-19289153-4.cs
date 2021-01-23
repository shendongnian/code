    using System;
    using System.Collections.Generic;
    using System.Text;
    
    
    namespace System
    {
    
    
        public class Locale
        {
            // http://msdn.microsoft.com/en-us/library/441722ys(v=vs.80).aspx
            // #pragma warning disable 414, 3021
    
            public static string GetText(string message)
            {
                return message;
            }
    
    
            public static string GetText(string format, params object[] args)
            {
                return string.Format(format, args);
            }
    
    
            /*
            public static object GetResource(string name)
            {
                return name;
            }
            */
    
    
        } // End Class Locale
    
    
    } // End Namespace System
