	// Return a reference to the container using the SAS URI.
	CloudBlobContainer container = new CloudBlobContainer(new Uri(sas));
	string date = DateTime.Now.ToString();
	try
	{
		//Write operation: write a new blob to the container. 
		CloudBlockBlob blob = container.GetBlockBlobReference("xamarinblob_" + date + ".txt");
		string blobContent = textEntry.Text; //"This blob was created with a shared access signature granting write permissions to the container. ";
		MemoryStream msWrite = new MemoryStream(Encoding.UTF8.GetBytes(blobContent));
		msWrite.Position = 0;
		using (msWrite)
		{
			await blob.UploadFromStreamAsync(msWrite);
		}
	}
	// Blob has now been uploaded
