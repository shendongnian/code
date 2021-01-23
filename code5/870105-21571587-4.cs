    public void SaveBitmap(string fileName, int width, int height, byte[] imageData)
            {
                
                var data = new byte[width * height * 4];
    
                int o = 0;
    
                for (var i = 0; i < width * height; i++)
                {
                    var value = imageData[i];
    
                    
                    data[o++] = value;
                    data[o++] = value;
                    data[o++] = value;
                    data[o++] = 0; 
                }
    
                unsafe
                {
                    fixed (byte* ptr = data)
                    {
                        
                        using (Bitmap image = new Bitmap(width, height, width * 4,
                                    PixelFormat.Format32bppRgb, new IntPtr(ptr)))
                        {
                            
                            image.Save(Path.ChangeExtension(fileName, ".jpg"));
                        }
                    }
                }
            }
