    // Precondition: bytes.Length == 16
	string ConvertToIPv6Address(byte[] bytes)
	{
		var str = new StringBuilder();
		for (var i = 0; i < bytes.Length; i+=2)
		{
			var segment = (ushort)bytes[i] << 8 | bytes[i + 1];			
			str.AppendFormat("{0:X}", segment);
			if (i + 2 != bytes.Length)
			{
				str.Append(':');
			}			
		}
		
		return str.ToString();
	}
