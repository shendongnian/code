    var sqsClient = AWSClientFactory.CreateAmazonSQSClient( 
                new AmazonSQSConfig
                {
                    MaxErrorRetry = 4 // the default is 4.
                });
