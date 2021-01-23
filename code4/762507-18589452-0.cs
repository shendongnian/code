    private static void test()
        {
            PInfo p = new PInfo();
            p.username = "test";
            p.computername = "test";
            p.PID = "test";
            List<PInfo> testlist = new List<PInfo>();
            testlist.Add(p);
            string json = JsonConvert.SerializeObject(testlist);
           
            var z = JsonConvert.DeserializeObject<List<PInfo>>(json);
        }
