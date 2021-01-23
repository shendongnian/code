	public static byte[] HexToBytes(string str, string separator = " ")
	{
		if (str == null)
		{
			throw new ArgumentNullException();
		}
		if (separator == null)
		{
			separator = string.Empty;
		}
		if (str == string.Empty)
		{
			return new byte[0];
		}
		int stride = 2 + separator.Length;
		if ((str.Length + separator.Length) % stride != 0)
		{
			throw new FormatException();
		}
		var bytes = new byte[(str.Length + separator.Length) / stride];
		for (int i = 0, j = 0; i < str.Length; i += stride)
		{
			bytes[j] = byte.Parse(str.Substring(i, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			j++;
			// There is no separator at the end!
			if (j != bytes.Length && separator != string.Empty)
			{
				if (string.Compare(str, i + 2, separator, 0, separator.Length) != 0)
				{
					throw new FormatException();
				}
			}
		}
		return bytes;
	}
	public static string BytesToHex(byte[] bytes, string separator = " ")
	{
		if (bytes == null)
		{
			throw new ArgumentNullException();
		}
		if (separator == null)
		{
			separator = string.Empty;
		}
		if (bytes.Length == 0)
		{
			return string.Empty;
		}
		var sb = new StringBuilder((bytes.Length * (2 + separator.Length)) - 1);
		for (int i = 0; i < bytes.Length; i++)
		{
			if (i != 0)
			{
				sb.Append(separator);
			}
			sb.Append(bytes[i].ToString("x2"));
		}
		return sb.ToString();
	}
	public static byte[] SimpleEncrypt(SymmetricAlgorithm algorithm, CipherMode cipherMode, byte[] key, byte[] iv, byte[] bytes)
	{
		algorithm.Mode = cipherMode;
		algorithm.Padding = PaddingMode.Zeros;
		algorithm.Key = key;
		algorithm.IV = iv;
		using (var encryptor = algorithm.CreateEncryptor())
		{
			return encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
		}
	}
	public static byte[] SimpleDecrypt(SymmetricAlgorithm algorithm, CipherMode cipherMode, byte[] key, byte[] iv, byte[] bytes)
	{
		algorithm.Mode = cipherMode;
		algorithm.Padding = PaddingMode.Zeros;
		algorithm.Key = key;
		algorithm.IV = iv;
		using (var encryptor = algorithm.CreateDecryptor())
		{
			return encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
		}
	}
