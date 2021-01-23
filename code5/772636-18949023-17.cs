    internal class DbMock
    {
        public static IDictionary<string, string> ScheduleMap = 
            new Dictionary<string, string>
            {
                {"00:01", "foo@gmail.com"},
                {"00:02", "bar@yahoo.com"}
            };
    }
