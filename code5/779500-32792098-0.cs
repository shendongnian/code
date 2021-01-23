	public static string DecodeSignedRequest(string signed_request)
	{
		try
		{
			if (signed_request.Contains("."))
			{
				string[] split = signed_request.Split('.');
				string signatureRaw = FixBase64String(split[0]);
				string dataRaw = FixBase64String(split[1]);
				// the decoded signature
				byte[] signature = Convert.FromBase64String(signatureRaw);
				byte[] dataBuffer = Convert.FromBase64String(dataRaw);
				// JSON object
				string data = Encoding.UTF8.GetString(dataBuffer);
				byte[] appSecretBytes = Encoding.UTF8.GetBytes(app_secret);
				System.Security.Cryptography.HMAC hmac = new System.Security.Cryptography.HMACSHA256(appSecretBytes);
				byte[] expectedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(split[1]));
				if (expectedHash.SequenceEqual(signature))
				{
					return data;
				}
			}
		}
		catch
		{
			// error
		}
		return "";
	}
	private static string FixBase64String(string str)
	{
		while (str.Length % 4 != 0)
		{
			str = str.PadRight(str.Length + 1, '=');
		}
		return str.Replace("-", "+").Replace("_", "/");
	}
