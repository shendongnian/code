    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<MailingList>();
            var grouped = list
                .GroupBy(m => m.ReportTypeID)
                .Select(g => new
                {
                    ReportTypeID = g.Key, 
                    Items = string.Join(", ", g)
                });
        }
    }
    class MailingList
    {
        public int ReportTypeID { get; set; }
        public string Acronym { get; set; }
    }
