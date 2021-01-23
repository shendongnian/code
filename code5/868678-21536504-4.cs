     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
    namespace DAL
    {
     public class GlobalClass
    {
        public string connectionString;
        public GlobalClass() 
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings.Get("ConnString");
        }
    }}
