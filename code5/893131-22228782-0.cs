    interface ITweet
    {
        object someData { get; }
    }
    
    class Tweet : ITweet
    {
        public object someData { get; set; }
    }
    
    class TweetSource
    {
        public event Action<ITweet> NewTweetEvent = delegate { };
    
        private Task tweetSourceTask;
    
        public void Start()
        {
            tweetSourceTask = new TaskFactory().StartNew(createTweetsForever);
        }
    
        private void createTweetsForever()
        {
            while (true)
            {
                Thread.Sleep(1000);
                var tweet = new Tweet{ someData = Guid.NewGuid().ToString() };
                NewTweetEvent(tweet);
            }
        }
    }
    
    class TweetHandler
    {
        public TweetHandler(Action<ITweet> handleTweet)
        {
            HandleTweet = handleTweet;
        }
    
        public void AddTweetToQueue(ITweet tweet)
        {
            queueOfTweets.Add(tweet);
        }
    
        public void HandleTweets(CancellationToken token)
        {
            ITweet item;
            while (queueOfTweets.TryTake(out item, -1, token))
            {
                HandleTweet(item);
            }
        }
    
        private BlockingCollection<ITweet> queueOfTweets = new BlockingCollection<ITweet>();
        private Action<ITweet> HandleTweet;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var handler1 = new TweetHandler(TweetHandleMethod1);
            var handler2 = new TweetHandler(TweetHandleMethod2);
    
            var source = new TweetSource();
            source.NewTweetEvent += handler1.AddTweetToQueue;
            source.NewTweetEvent += handler2.AddTweetToQueue;
    
            // start up the task threads (2 of them)!
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var taskFactory = new TaskFactory(token);
            var task1 = taskFactory.StartNew(() => handler1.HandleTweets(token));
            var task2 = taskFactory.StartNew(() => handler2.HandleTweets(token));
    
            // fire up the source
            source.Start();
    
            Thread.Sleep(10000);
            tokenSource.Cancel();
        }
    
        static void TweetHandleMethod1(ITweet tweet)
        {
            Console.WriteLine("Did action 1 on tweet {0}", tweet.someData);
        }
    
        static void TweetHandleMethod2(ITweet tweet)
        {
            Console.WriteLine("Did action 2 on tweet {0}", tweet.someData);
        }
    }
