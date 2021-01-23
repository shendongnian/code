	public static String sha256_hash(String value)
	{
		StringBuilder Sb = new StringBuilder();
		using (SHA256 hash = SHA256Managed.Create())
		{
			Encoding enc = Encoding.UTF8;
			Byte[] result = hash.ComputeHash(enc.GetBytes(value));
			foreach (Byte b in result)
			{
				Sb.Append(b.ToString("x"));
			}
		}
		return Sb.ToString();
	}
