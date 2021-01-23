    class Tweet
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    private static readonly IEnumerable<Tweet> SomeTweets = new[]
    {
        new Tweet { Id = 123, Text = "This is tweet 123" },
        new Tweet { Id = 234, Text = "This is tweet 234" },
        new Tweet { Id = 345, Text = "This is tweet 345" }
    };
