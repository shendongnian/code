    public class FeedItem<T>
    {
        public List<T> Attributes { get; set; }
    }
    var feedData = new List<FeedItem<Paper>>();
    feedData.Add(new FeedItem<Paper>
        {
            Attributes = new List<Paper>() {
                
            }
        });
