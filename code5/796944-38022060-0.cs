            public static void MoveFiles()
            {
                BasicAWSCredentials basicCredentials = new BasicAWSCredentials("your access key", "your secret key");
                AmazonS3Config configurationClient = new AmazonS3Config();
                configurationClient.RegionEndpoint = RegionEndpoint.EUCentral1;
                try
                {
                    using (AmazonS3Client clientConnection = new AmazonS3Client(basicCredentials, configurationClient))
                    {
                        S3DirectoryInfo source = new S3DirectoryInfo(clientConnection, "sourcebucketname", "sourcefolderkey");
                        S3DirectoryInfo target = new S3DirectoryInfo(clientConnection, "targetbucketname", "destinationbucketname");
                        source.CopyTo(target);
                        
                    }
                }
                catch(Exception ex)
                {
                    
                }
            
            
                
            }
