    TwitterCredentials.SetCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");
    var tweet = Tweet.PublishTweet("Hello!");
    
    if (tweet == null)
    {
        var exceptionDetails = ExceptionHandler.GetLastException().TwitterExceptionInfos.First().Message;
    }
