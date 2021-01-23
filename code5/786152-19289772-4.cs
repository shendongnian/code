    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Script.Serialization;
    
    namespace Stackoverflow.Helpers
    {
        public static class JsonHelper
        {
            private static JavaScriptSerializer ser = new JavaScriptSerializer();
            public static T ToJSON<T>(this string js) where T : class
            {
                return ser.Deserialize<T>(js);
            }
    
            public static string JsonToString(this object obj)
            {
                return ser.Serialize(obj);
            }
        }
    }
