    		public static Texture2D TextureFromStream(GraphicsDevice graphicsDevice, Stream stream, String dbg_nm)
		{			
    		#if WP8
			byte [] b = new byte[4];
			stream.Read(b, 0, 4);
			stream.Seek(0, SeekOrigin.Begin);
			int stream_type = getStreamType(b, 0);
			Texture2D result = null;
			if (stream_type == 1 || stream_type == 0)
			{
				var image = new ExtendedImage();
				if (stream_type == 0)
					new JpegDecoderNano().Decode(image, stream);
				else
				{
					try
					{
						new PngDecoder().Decode(image, stream);
					}
					catch (System.Exception ex)
					{
						Debug.WriteLine("Error reading " + dbg_nm + ":" + ex.Message);
					}					
				}
				var Colors = new Color[image.Pixels.Length / 4];
				for (var i = 0; i < image.Pixels.Length / 4; i++)
				{
					Color unpackedColor = new Color();
					unpackedColor.R = (byte)(image.Pixels[i * 4 + 0]);
					unpackedColor.G = (byte)(image.Pixels[i * 4 + 1]);
					unpackedColor.B = (byte)(image.Pixels[i * 4 + 2]);
					unpackedColor.A = (byte)(image.Pixels[i * 4 + 3]);
					Colors[i] = unpackedColor;
				}
				Texture2D texture2D = new Texture2D(graphicsDevice, image.PixelWidth, image.PixelHeight);
				texture2D.SetData(Colors);
				result = texture2D;
			}
			
			return result;
		
    		#else
			return Texture2D.FromStream(graphicsDevice,  stream);
    		#endif
		}
