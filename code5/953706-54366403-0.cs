    [HttpPost]
	public async Task<IActionResult> UploadFile(IFormFile file)
	{
		try
		{
			if (file != null && file.Length > 0)
			{
				var relativePath = string.Empty;
				using (var client = new AmazonS3Client("awsAccessKeyId", "awsSecretAccessKey", RegionEndpoint.USEast1))
				{
					using (var newMemoryStream = new MemoryStream())
					{
						file.CopyTo(newMemoryStream);
						var uploadRequest = new TransferUtilityUploadRequest
						{
							InputStream = newMemoryStream,
							Key = file.FileName,
							BucketName = "bucketName",
							CannedACL = S3CannedACL.PublicRead
						};
						var fileTransferUtility = new TransferUtility(client);
						await fileTransferUtility.UploadAsync(uploadRequest);
						relativePath = "urlS3" + "bucketName" + "/" + file.FileName;
					}
				}
				return Ok(new { FileUrl = relativePath });
			}
			return BadRequest("Select a file");
		}
		catch (Exception exception)
		{
			return BadRequest(exception.Message);
		}
	}
