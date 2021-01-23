    public Point[] GetPixelsFromRGB(byte[] rgbData, int stride, Color colorToFind){
      int k = stride/4;
      return rgbData.Select((x,i)=>new{x,i})
                    .GroupBy(a=>a.i/4,(key,a)=>a.ToArray())
                    .Where(g=>g[0].x == colorToFind.Red &&
                              g[1].x == colorToFind.Green &&
                              g[2].x == colorToFind.Blue && g[3].x == 255)
                    .Select(g=> new Point(g[0].i%k, g[0].i / k)).ToArray();
    }
    //Use this method to get the rgbData
    int stride = bitmap.PixelWidth * 4;
    byte[] rgbData = new byte[stride * bitmap.PixelHeight];
    bitmap.CopyPixels(rgbData, stride, 0);
    //then call the method above:
    var pixels = GetPixelsFromRGB(rgbData, stride, Colors.Red);
