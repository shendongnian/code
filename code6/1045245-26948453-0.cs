	public void convertSignedToUnsignedBytes(byte[] b)
	{
		for (int i = 0; i < b.Length; i++) {
			if (b[i] >= 128) b[i] -= 128;
			else b[i] += 128;
		}
	}
