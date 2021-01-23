        static void Main(string[] args)
        {
            var conOpt = new ConnectionOptions();
            conOpt.Impersonation = ImpersonationLevel.Impersonate;
            conOpt.EnablePrivileges = true;
            conOpt.Username = "username";
            conOpt.Password = "password";
            conOpt.Authority = string.Format("ntlmdomain:{0}", "yourdomain.com");
            
            var scope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "yourservername.yourdomain.com"), conOpt);
            
            scope.Connect();
            bool isConnected = scope.IsConnected;
            if (isConnected)
            {
                /* entire day */ string dateTime = getDmtfFromDateTime(DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0)));
                string dateTime = getDmtfFromDateTime("09/06/2014 17:00:08"); // DateTime specific
                SelectQuery query = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'Application' and TimeGenerated >='" + dateTime + "'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection logs = searcher.Get();
                foreach (var log in logs)
                {
                    Console.WriteLine("Message : {0}", log["Message"]);
                    Console.WriteLine("ComputerName : {0}", log["ComputerName"]);
                    Console.WriteLine("Type : {0}", log["Type"]);
                    Console.WriteLine("User : {0}", log["User"]);
                    Console.WriteLine("EventCode : {0}", log["EventCode"]);
                    Console.WriteLine("Category : {0}", log["Category"]);
                    Console.WriteLine("SourceName : {0}", log["SourceName"]);
                    Console.WriteLine("RecordNumber : {0}", log["RecordNumber"]);
                    Console.WriteLine("TimeWritten : {0}", getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));
                }
            }
            //ReadLog();
            Console.ReadLine();
        }
        private static string getDmtfFromDateTime(DateTime dateTime) 
        {
            return ManagementDateTimeConverter.ToDmtfDateTime(dateTime);
        }
        private static string getDmtfFromDateTime(string dateTime)
        {
            DateTime dateTimeValue = Convert.ToDateTime(dateTime);
            return getDmtfFromDateTime(dateTimeValue);
        }
        private static string getDateTimeFromDmtfDate(string dateTime)
        {
            return ManagementDateTimeConverter.ToDateTime(dateTime).ToString();
        }
