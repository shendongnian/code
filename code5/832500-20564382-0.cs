	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct FastPixel
	{
		public readonly byte R;
		public readonly byte G;
		public readonly byte B;
	}
	private static void Main()
	{
		unsafe
		{
			// 8-bit.
			byte[] b1 =
			{
				0x1, 0x2, 0x3,
				0x6, 0x7, 0x8,
				0x12, 0x13, 0x14
			};
			fixed (byte* buffer = b1)
			{
				var fastPixel = (FastPixel*) buffer;
				var pixelSize = Marshal.SizeOf(typeof (FastPixel));
				var bufferLength = b1.Length / pixelSize;
				for (var i = 0; i < bufferLength; i++)
				{
					Console.WriteLine("AVERAGE {0}", (fastPixel[i].R + fastPixel[i].G + fastPixel[i].B)/pixelSize);
				}
			}
		}
	}
