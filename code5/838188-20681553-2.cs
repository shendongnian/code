	public void CreateFolder(string awsBucketName, string awsFolderName)
	{
		EncryptionMaterials encryptionMaterials = new EncryptionMaterials(RSA.Create());
		AmazonS3EncryptionClient client = new AmazonS3EncryptionClient(encryptionMaterials);
			if ((cloudKaseClient != null) & (_Security.IsTokenAuthenticate(tokenUsr, tokenPasswd)))
			{
				PutObjectRequest putObjectRequest = new PutObjectRequest
				{
					BucketName = awsBucketName,
					StorageClass = S3StorageClass.Standard,
					ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
					CannedACL = S3CannedACL.Private,
					Key = awsFolderName + "/",
					ContentBody = awsFolderName
				};
				client.PutObject(putObjectRequest);
			
		}
	}
