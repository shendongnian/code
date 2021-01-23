    public void SeeHashTag(string hashtag)
    {
        Console.WriteLine("==================================\nViewing all tweets containing the hashtag: " + hashtag + "\n==================================\n");
        for (int x = 0; x < tweets.Count; x++)
        {
            if (tweets[x].HashTag == hashtag)
            {
                Console.WriteLine(tweets[x]);
            }
        }
        Console.WriteLine("Total Number of tweets:" + tweets.Count(tw => tw.HashTag == hashtag));
    }
