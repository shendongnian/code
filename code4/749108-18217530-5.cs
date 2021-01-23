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
    // items is now an IEnumerable<Test>, you can do:
    foreach (var item in items)
    {
        Console.WriteLine("{0} ({1})", item.name, item.phone);
    }
