    using (client = Amazon.AWSClientFactory.CreateAmazonEC2Client(accessKeyID, secretAccessKeyID))
    {
        DescribeTagsRequest request = new DescribeTagsRequest
        {
            Filters = new List<Filter>
            {
                new Filter{ Name = "key", Values = new List<string>{"domain"}},
                new Filter{ Name = "resource-type", Values = new List<string>{"instance"}}
            }
        };
    
        DescribeTagsResponse responce = client.DescribeTags(request);  //**error**
    }
