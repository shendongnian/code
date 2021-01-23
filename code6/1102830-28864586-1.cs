    public class FeedItem<T>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<T> Attributes { get; set; }
        public DateTime Date { get; set; }
    }
    var feedData = new List<FeedItem<Paper>>();
    feedData.Add(new FeedItem<Paper>
            {
                Date = new DateTime(2015, 3, 3),
                Type = "library",
                Id = 1,
                Attributes = new List<Paper>() { 
                 ... add papers here ... 
                }
            });
