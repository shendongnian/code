    private static void SequencesInner(byte[] bytes, int i, Action<byte[]> action)
    {
    	if (i == bytes.Length)
    	{
    		action(bytes);
    	}
    	else
    	{
    		int j = i + 1;
    		for (int v = 0; v < 256; v++)
    		{
    			bytes[i] = Convert.ToByte(v);
    			SequencesInner(bytes, j, action);
    		}
    	}
    }
    
    private static void Sequences(int length, Action<byte[]> action)
    {
    	for (int n = 1; n <= length; n++)
    	{
    		SequencesInner(new byte[n], 0, action);
    	}
    }
