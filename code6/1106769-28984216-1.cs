     GoogleConnector ga = new GoogleConnector(@"C:\Users\Sun\Desktop\infibeam\NewDemoProject-199399.p12", "554818524279-g0erg68fvl@developer.gserviceaccount.com");
    
                var PageViews = ga.GetAnalyticsData("ga:98196", new string[] { "ga:pageviews" },
                    DateTime.Now.AddDays(-100), DateTime.Now).Rows[0][0];
                var sessionDuration = ga.GetAnalyticsData("ga:98196", new string[] { "ga:sessionDuration" },
                 DateTime.Now.AddDays(-100), DateTime.Now).Rows[0][0];
                var avgSessionDuration = ga.GetAnalyticsData("ga:98196", new string[] { "ga:avgSessionDuration" },
               DateTime.Now.AddDays(-100), DateTime.Now).Rows[0][0];
    
                var bounceRate = ga.GetAnalyticsData("ga:98196", new string[] { "ga:bounceRate" },
              DateTime.Now.AddDays(-100), DateTime.Now).Rows[0][0];
    
                var sessions = ga.GetAnalyticsData("ga:98196", new string[] { "ga:sessions" },
         DateTime.Now.AddDays(-100), DateTime.Now).Rows[0][0];
                var bounces = ga.GetAnalyticsData("ga:98196", new string[] { "ga:bounces" },
        DateTime.Now.AddDays(-100), DateTime.Now).Rows[0][0];
                var hits = ga.GetAnalyticsData("ga:98196", new string[] { "ga:hits" },
       DateTime.Now.AddDays(-100), DateTime.Now).Rows[0][0];
    
       Console.WriteLine("page views : {0}\n Session Duration : {1} \n Avg Session Duration : {2}\n Bounce Rate :{3}\n hits: {4}\n Sessions:{5} ", PageViews , sessionDuration, avgSessionDuration, bounceRate, sessions, bounces, hits, sessions);
                Console.Read();
               
            }
