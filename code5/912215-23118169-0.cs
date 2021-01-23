        private static DynamicJsonObject getBaseline(string day, long projectID, long ReleaseID)
        {
            int pageSize = 200;
            string uri = @"https://rally1.rallydev.com/analytics/v2.0/service/rally/workspace/14457696030/artifact/snapshot/query.js?find={%22_ProjectHierarchy%22:" + 
                         projectID + @",%22_TypeHierarchy%22:%22HierarchicalRequirement%22,%22Release%22:{$in:[" + ReleaseID + @"]},%22Children%22:null,%22__At%22:%22" + 
                         day + @"T00Z%22}&fields=[%22PlanEstimate%22,%22ScheduleState%22]&hydrate=[%22ScheduleState%22]&start=0&pagesize=" + pageSize;
            DynamicJsonObject response = HttpGet(uri);
            DynamicJsonObject points = new DynamicJsonObject();
            foreach (var story in response["Results"])
            {
                // Do whatever
            }
            return points;
        }
        public static DynamicJsonObject HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.Credentials = GetCredential();
            req.PreAuthenticate = true;
            req.ContentType = "application/json";
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            DynamicJsonObject result = new DynamicJsonSerializer().Deserialize(sr.ReadToEnd());
            // Not sure if all of these are necessary
            sr.Close(); sr.Dispose();
            resp.Close();
            sr.Close(); sr.Dispose();
            return result;
        }
        private static CredentialCache GetCredential()
        {
            if (credentialCache == null)
            {
                string url = @"https://rally1.rallydev.com/analytics/v2.0/service/rally/workspace/14457696030/artifact/snapshot/query.js?";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                credentialCache = new CredentialCache();
                String user = ConfigurationManager.AppSettings["user"];
                String password = ConfigurationManager.AppSettings["password"];
                credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(user, password));
            }
            return credentialCache;
        }
