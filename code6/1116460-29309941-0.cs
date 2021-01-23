    using (var content = new MultipartFormDataContent())
	{
	    var fileNameContent = new StringContent(listFile.Name);
		content.Add(fileNameContent, "\"file_name\"");
		var listContent = new StringContent(contactListId);
		content.Add(listContent, "\"lists\"");
		var dataContent = new ByteArrayContent(File.ReadAllBytes(listFile.FullName));
		content.Add(dataContent, "\"data\"");
        result = client.PostAsync(FullApiAddress, content).Result;
    }
