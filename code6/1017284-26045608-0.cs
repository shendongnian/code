	using (var stream = new MemoryStream())
	using (SvnClient client = new SvnClient())
	{
        string yourUrl = "http://svn.apache.org/repos/asf/subversion/trunk/CHANGES";
		if (client.Write(new SvnUriTarget(yourUrl), stream))
		{
			// reset the position to read from the beginning
			stream.Position = 0;
			using (var reader = new StreamReader(stream))
			{
				string contents = reader.ReadToEnd();
				// find your token
			}
		}
	}
