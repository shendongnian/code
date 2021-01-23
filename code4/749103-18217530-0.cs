    class Test
    {
        public string name { get; set; }
        public string account_type { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string account_details { get; set; }
        public string gender { get; set; }
    }
    var items = connection.Query<Test>(var1.ToString());
    // items is now a collection of Test. a List<Test> probably
