    var imageBinary = File.ReadAllBytes("path");
    var media = Upload.UploadImage(imageBinary);
    var tweet = Tweet.PublishTweet("hello", new PublishTweetOptionalParameters
    {
        Medias = { media }
    });
