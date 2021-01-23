    var config = new AmazonEC2Config { RegionEndpoint = Amazon.RegionEndpoint.APSoutheast2};
    var credentials = new BasicAWSCredentials(accessKey, secretKey);
    
    using (var client = Amazon.AWSClientFactory.CreateAmazonEC2Client(credentials, config))
    {
        var dsgRequest = new DescribeSecurityGroupsRequest();
        var dsgResponse = client.DescribeSecurityGroups(dsgRequest);
        List<SecurityGroup> mySGs = dsgResponse.SecurityGroups;
        foreach (SecurityGroup item in mySGs)
        {
            Console.WriteLine("Existing security group: " + item.GroupId);
        }
    }
