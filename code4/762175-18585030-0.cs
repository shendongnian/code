    public class UploadFile
    {
    	public UploadFile(Stream data, string fieldName, string fileName, string contentType)
    	{
    		this.Data = data;
    		this.FieldName = fieldName;
    		this.FileName = fileName;
    		this.ContentType = contentType;
    	}
    
    	public UploadFile(string fileAbsPath, string fieldName, string fileName, string contentType)
    		: this(File.OpenRead(fileAbsPath), fieldName, fileName, contentType)
    	{
    	}
    
    	public UploadFile(string fileAbsPath, string fieldName, string contentType)
    		: this(fileAbsPath, fieldName, Path.GetFileName(fileAbsPath), contentType)
    	{
    	}
    
    
    	public UploadFile(string fileAbsPath)
    		: this(fileAbsPath, null, Path.GetFileName(fileAbsPath), "application/octet-stream")
    	{
    	}
    
    	public Stream Data { get; set; }
    
    	public string FieldName { get; set; }
    
    	public string FileName { get; set; }
    
    	public string ContentType { get; set; }
    
    	public DateTimeOffset? CreationDate { get; set; }
    
    	public DateTimeOffset? ModificationDate { get; set; }
    }
    	
    class MimePart
    {
    	private readonly NameValueCollection headers = new NameValueCollection();
    	private byte[] header;
    
    	private Stream data;
    
    	public override Stream Data
    	{
    		get
    		{
    			return this.data;
    		}
    	}
    
    	public void SetStream(Stream stream)
    	{
    		this.data = stream;
    	}
    
    	public NameValueCollection Headers
    	{
    		get { return this.headers; }
    	}
    
    	public byte[] Header
    	{
    		get { return this.header; }
    	}
    
    	public long GenerateHeaderFooterData(string boundary)
    	{
    		var sb = new StringBuilder();
    		sb.Append("--");
    		sb.Append(boundary);
    		sb.AppendLine();
    
    		foreach (string key in this.headers.AllKeys)
    		{
    			sb.Append(key);
    			sb.Append(": ");
    			sb.AppendLine(this.headers[key]);
    		}
    
    		sb.AppendLine();
    
    		this.header = Encoding.UTF8.GetBytes(sb.ToString());
    
    		return this.header.Length + this.Data.Length + 2;
    	}
    }
    	
    private IList<MimePart> GenerateMimePartsList(IEnumerable<UploadFile> files)
    {
    	var mimeParts = new List<MimePart>();
    
    	int nameIndex = 0;
    
    	// Files data
    	foreach (UploadFile file in files)
    	{
    		var streamMimePart = new StreamMimePart();
    
    		if (string.IsNullOrEmpty(file.FieldName))
    		{
    			file.FieldName = "file" + nameIndex++;
    		}
    
    		var contentDispositionValues = new List<string>();
    		contentDispositionValues.Add("form-data");
    		contentDispositionValues.Add(string.Format("name=\"{0}\"", file.FieldName));
    		contentDispositionValues.Add(string.Format("filename=\"{0}\"", file.FileName));
    
    		if (file.CreationDate.HasValue)
    		{
    			contentDispositionValues.Add(string.Format("creation-date=\"{0}\"", file.CreationDate.Value.ToString("R")));
    		}
    
    		if (file.ModificationDate.HasValue)
    		{
    			contentDispositionValues.Add(string.Format("modification-date=\"{0}\"", file.ModificationDate.Value.ToString("R")));
    		}
    
    		// "form-data; name=\"" + file.FieldName + "\"; filename=\"" + file.FileName + "\"";
    		streamMimePart.Headers["Content-Disposition"] = string.Join("; ", contentDispositionValues);
    		streamMimePart.Headers["Content-Type"] = file.ContentType;
    		streamMimePart.SetStream(file.Data);
    
    		mimeParts.Add(streamMimePart);
    	}
    
    	return mimeParts;
    }
    		
    public void PostMultipart(Uri uri, IEnumerable<UploadFile> files)
    {
    	var mimeParts = this.GenerateMimePartsList(files);
    
    	var boundary = "----------" + DateTime.Now.Ticks.ToString("x");
    
    	byte[] footer = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
    
    	var request = (HttpWebRequest)WebRequest.Create(uri);
    	request.Method = "POST";
    	request.ContentType = "multipart/form-data; boundary=" + boundary;
    	request.ContentLength = mimeParts.Sum(part => part.GenerateHeaderFooterData(boundary)) + footer.Length;
    	try
    	{
    		// Write data
    		byte[] buffer = new byte[8192];
    		byte[] afterFile = Encoding.UTF8.GetBytes("\r\n");
    
    		using (Stream requestStream = request.GetRequestStream())
    		{
    			foreach (MimePart mimePart in mimeParts)
    			{
    				requestStream.Write(mimePart.Header, 0, mimePart.Header.Length);
    
    				int read;
    				while ((read = mimePart.Data.Read(buffer, 0, buffer.Length)) > 0)
    				{
    					requestStream.Write(buffer, 0, read);
    				}
    
    				mimePart.Data.Dispose();
    
    				requestStream.Write(afterFile, 0, afterFile.Length);
    			}
    
    			requestStream.Write(footer, 0, footer.Length);
    		}
    
    		// Get response 
    		using (var response = (HttpWebResponse)request.GetResponse())
    		{
    			var responseText = response.ReadAsString();
    
    			return;
    		}
    	}
    	catch (WebException webException)
    	{
    		this.HandleErrorResponse(webException);
    	}
    	finally
    	{
    		foreach (var mimePart in mimeParts)
    		{
    			if (mimePart.Data != null)
    			{
    				mimePart.Data.Dispose();
    			}
    		}
    	}
    
    	return;
    }
