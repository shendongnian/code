	Bitmap bmp = new Bitmap("img.bmp");
	var bits = bmp.LockBits(new Rectangle(0,0,bmp.Width,bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
	try{
		unsafe{
			using(Stream bmpstream = new UnmanagedMemoryStream((byte*)bits.Scan0, bits.Height*bits.Stride))
			{
				BinaryReader reader = new BinaryReader(bmpstream);
				for(int y = 0; y < bits.Height; y++)
				{
					bmpstream.Seek(bits.Stride*y, SeekOrigin.Begin);
					for(int x = 0; x < bits.Width; x++)
					{
						byte b = reader.ReadByte();
						byte g = reader.ReadByte();
						byte r = reader.ReadByte();
						byte a = reader.ReadByte();
					}
				}
			}
		}
	}finally{
		bmp.UnlockBits(bits);
	}
