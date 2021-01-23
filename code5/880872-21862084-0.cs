    public static Bitmap ConvertBitMap(int width, int height, byte[] imageData)
            {
                var data = new byte[imageData.Length * 4];
                int o = 0;
    
                for (var i = 0; i < imageData.Length ; i++)
                {
                    var value = imageData[i];
    
    
                    data[o++] = value;
                    data[o++] = value;
                    data[o++] = value;
                    data[o++] = 0;
                }
               ...
               ...
               ..
               ..
    }
