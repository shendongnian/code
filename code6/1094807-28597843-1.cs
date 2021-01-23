	public static void Copy(IntPtr source, ushort[] destination, int startIndex, int length)
	{
		unsafe
		{
			var sourcePtr = (ushort*)source;
			for(int i = startIndex; i < startIndex + length; ++i)
			{
				destination[i] = *sourcePtr++;
			}
		}
	}
