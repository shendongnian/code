	private void Action1(byte[] bytes, int i, Action<byte[]> action)
	{
		if (i == bytes.Length)
		{
			action(bytes);
		}
		else
		{
			for (int j = i + 1, v = 0; v < 256; v++)
			{
				bytes[i] = Convert.ToByte(v);
				Action1(bytes, j, action);
			}
		}
	}
	private void Action(int length, Action<byte[]> action)
	{
		for (int n = 1; n <= length; n++)
		{
			Action1(new byte[n], 0, action);
		}
	}
