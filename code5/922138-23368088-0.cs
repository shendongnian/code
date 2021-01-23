    			AmazonS3Config S3Config = new AmazonS3Config
									  {
										  ServiceURL = "s3.amazonaws.com",
										  RegionEndpoint = RegionEndpoint.USWest2,
										  CommunicationProtocol = Protocol.HTTPS,
										  ProxyHost = Proxy.Host,
										  ProxyPort = Convert.ToInt32(Proxy.Port),
										  ProxyCredentials = new NetworkCredential
															 {
																 UserName = Proxy.User,
																 Password = Proxy.Password
															 }
									  };
			_S3Client = AWSClientFactory.CreateAmazonS3Client(AccessKey, SecretKey, S3Config);
			_ObjRequest = new GetObjectRequest
										  {
											  BucketName = BucketName,
											  Key = Key
										  };
			_ObjResponse = _S3Client.GetObject(_ObjRequest);
			return (_ObjResponse != null);
