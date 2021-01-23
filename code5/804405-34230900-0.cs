	string root = HttpContext.Current.Server.MapPath("~/App_Data");
	var provider = new MultipartFormDataStreamProvider(root);
	var filesReadToProvider = await Request.Content.ReadAsMultipartAsync(provider);
	
	foreach (var file in provider.FileData)
	{
		var fileName = file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
		byte[] documentData;
		documentData = File.ReadAllBytes(file.LocalFileName);
		DAL.Document newRecord = new DAL.Document
		{
			PathologyRequestId = PathologyRequestId,
			FileName = fileName,
			DocumentData = documentData,
			CreatedById = ApplicationSecurityDirector.CurrentUserGuid,
			CreatedDate = DateTime.Now,
			UpdatedById = ApplicationSecurityDirector.CurrentUserGuid,
			UpdatedDate = DateTime.Now
		};
		context.Documents.Add(newRecord);
		context.SaveChanges();
	}
