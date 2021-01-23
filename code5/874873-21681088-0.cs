     #region public byte[] BitmapToBytes(Image bmp, ImageFormat p_Format)
            public byte[] BitmapToBytes(Image bmp, ImageFormat p_Format)
    		{
    			MemoryStream stream = new MemoryStream();
    			try
    			{
    				bmp.Save(stream, p_Format);
    			}
    			catch (Exception ex)
    			{
    			}
    			return stream.ToArray();
    		}
            #endregion
    
            #region public Image BytesToBitmap(byte[] bytes)
            public Image BytesToBitmap(byte[] bytes)
    		{
    			MemoryStream stream = null;
    			try
    			{
    				stream = new MemoryStream(bytes);
    			}
    			catch (Exception ex)
    			{
    			}
    
                return new Bitmap(stream);
            }
            #endregion
