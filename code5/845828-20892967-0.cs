    using(var client = new AmazonS3Client())
    {
        // use the client here in the using scope
    }
    // the Dispose() is called after you leave scope of using statement
