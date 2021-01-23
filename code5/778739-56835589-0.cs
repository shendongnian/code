    string content = "{ test: \"olé\" }";
	byte[] bytes			= Encoding.UTF8.GetBytes(content);
	_Request.ContentLength	= bytes.Length;
	using ( var writer = _Request.GetRequestStream() )
		writer.Write(bytes, 0, bytes.Length);
