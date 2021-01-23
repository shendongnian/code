    IAmazonEC2 ec2;
    AmazonEC2Config ec2conf = new AmazonEC2Config();
    ec2 = AWSClientFactory.CreateAmazonEC2Client(ec2conf);
    // CreateImageResponse imageResp;
    Amazon.EC2.Model.CreateImageResponse imageResp = null;
