 	public byte[] ToByteArray()
	{
		List<byte> result = new List<byte>();
		
		result.AddRange(BitConverter.GetBytes(One));
		result.AddRange(BitConverter.GetBytes(Two));
		result.AddRange(BitConverter.GetBytes(Three));
		result.AddRange(BitConverter.GetBytes(Four));
		
		return result.ToArray();
	}
