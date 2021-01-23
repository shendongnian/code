	public byte[] GetImageFromFile(string fileName)
	{
        var applicationTypeInfo = Application.Current.GetType().GetTypeInfo();
		byte[] buffer;
		using (var stream = applicationTypeInfo.Assembly.GetManifestResourceStream($"{applicationTypeInfo.Namespace}.fileName"))
		{
			if (stream != null)
			{
				long length = stream.Length;
				buffer = new byte[length];
				stream.Read(buffer, 0, (int)length);
			}
		}
		return buffer;
	}
