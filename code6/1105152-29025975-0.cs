    public class MyClass
    {
        public class DetailsTable
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public string StatusAt { get; set; }
            public string Status { get; set; }
        }
        public class RootObject
        {
            public string ItemNumber { get; set; }
            public string BookedAt { get; set; }
            public string BookedOn { get; set; }
            public string DeliveredAt { get; set; }
            public string DeliveredOn { get; set; }
            public List<DetailsTable> DetailsTable { get; set; }
        }
    }
