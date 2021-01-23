	public static int CalculateCheckSum(byte[] strsResponse)
	{
		short crc = 0;
		try
		{
			ushort ch;
			for (int i = 0; i < strsResponse.Length; i++)
			{
					ch = (ushort)(strsResponse[i] << 8);
					for (int j = 0; j < 8; j++)
					{
						bool xorFlag = ((ch & 0x8000) ^ (cword & 0x8000)) == 0 ? false : true;
						if (xorFlag)
						{
							crc = (ushort)((crc <<= 1) ^ 4129);
						}
						else
						{
							crc <<= 1;
						}
						ch <<= 1;
					}
			}
		}
		catch (Exception ex)
		{
			return crc = 0;
		}
		return crc;
	}
