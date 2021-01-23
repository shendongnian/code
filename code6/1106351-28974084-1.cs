     class Output
    {
        public string Name { get; set; }
        public int[] DupTrans { get; set; }
    }
    class UsageData
    {
        public string UsageType { get; set; }
        public int DupTrans { get; set; }
        public int UniqTrans { get; set; }
    }
     List<UsageData> usageData = new List<UsageData>()
            {
                new UsageData(){UsageType = "FIND", DupTrans  = 190, UniqTrans = 55 },
                new UsageData(){UsageType = "PARTS", DupTrans  = 107, UniqTrans = 51 }
            };
            var myObj = new { Name = "Duplicate Transactions", DupTrans = usageData.Select(x => x.DupTrans).ToArray() };
            string str = JsonConvert.SerializeObject(myObj);
