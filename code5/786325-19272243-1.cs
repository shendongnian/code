    using System;
    using System.Configuration;
    using System.Text;
    
    namespace WindowsFormsApplication4
    {
        class Config
        {
            public static string CONNECTION_STRING_1
            {
                get
                {
                    return ConfigurationManager.ConnectionStrings["Conn1"].ConnectionString;
                }
            }
    
            public static string CONNECTION_STRING_2
            {
                get
                {
                    return ConfigurationManager.ConnectionStrings["Conn2"].ConnectionString;
                }
            }
        }
    }
