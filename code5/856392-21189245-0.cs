    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Teradata.Client.Provider;
    
    namespace Teradata.Client.Provider.ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                TdConnection cn = new TdConnection();
                TdConnectionStringBuilder conStrBuilder = new TdConnectionStringBuilder();
    
                conStrBuilder.DataSource = "DSN";
                // conStrBuilder.Database = "optional";
    
                conStrBuilder.UserId = "user"; conStrBuilder.Password = "pass";
                cn.ConnectionString = conStrBuilder.ConnectionString;
    
                cn.Open();
    
                Console.WriteLine("connection successfull");
            }
        }
    }
