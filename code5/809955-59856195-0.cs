	var putObjectRequest = new PutObjectRequest()
	{
		BucketName = bucketName,
		Key = key,
		ContentBody = content,
		MD5Digest = AmazonS3Util.GenerateChecksumForContent(content, true),
	};
	if (retainUntilDate.HasValue)
	{
		putObjectRequest.ObjectLockMode = ObjectLockMode.Governance;
		putObjectRequest.ObjectLockRetainUntilDate = retainUntilDate.Value;
	}
