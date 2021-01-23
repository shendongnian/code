    public static class Class1
    {
        public static Dictionary<int, string> Dict1 { get; set; }
        public static void StatDict(int EventNumber, string EventCode)
        {
            Dict1 = new Dictionary<int, sting>();
            Dict1.Add(EventNumber, EventCode);
        }
    }
    public static class Class2
    {
        public void CompareIntToDictionary()
        {
            int Compare = 4;
            if (Class1.Dict1.ContainsKey(Compare))
            {
                var eventCode = Class1.Dict1[Compare];
                // Do something!!!
            }
        }
    }
