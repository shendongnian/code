    string amiID = ConfigurationManager.AppSettings[AmazonConstants.AwsImageId];
                    string keyPairName = ConfigurationManager.AppSettings[AmazonConstants.AwsKeyPair];
                    List<string> groups = new List<string>() { ConfigurationManager.AppSettings[AmazonConstants.AwsSecurityGroupId] };
                    var launchRequest = new RunInstancesRequest()
                    {
                        ImageId = amiID,
                        InstanceType = ConfigurationManager.AppSettings[AmazonConstants.AwsInstanceType],
                        MinCount = 1,
                        MaxCount = 1,
                        KeyName = keyPairName,
                        SecurityGroupIds = groups,
                        SubnetId = ConfigurationManager.AppSettings[AmazonConstants.AwsSubnetId]
                    };
                    RunInstancesResponse runInstancesResponse = amazonEc2client.RunInstances(launchRequest);
                    RunInstancesResult runInstancesResult = runInstancesResponse.RunInstancesResult;
                    Reservation reservation = runInstancesResult.Reservation;
