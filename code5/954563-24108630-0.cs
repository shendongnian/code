    public void SeeHashTag(string hashtag)
    {
        int numHashes = 0;
        string tweets = String.Empty;
        foreach (Tweet Tweets in tweets)
        {
            if (Tweets.HashTag == hashtag)
            {
                tweets += hashtag + '\n';
                numHashes++;
            }
        }
        Console.WriteLine("==================================\nViewing " + numHashes + "tweet" + numHashes == 1? "":"s" + " containing the hashtag: " + hashtag + "\n==================================\n");
        Console.Write(tweets);
    }
