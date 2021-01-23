    public static Color FindMostCommonColor(Image image)
    {
        // Avoid unnecessary getter calls
        Int32 height = image.Height;
        Int32 width = image.Width;
        Int32 stride;
        Byte[] imageData;
        using (Bitmap bm = new Bitmap(width, height, PixelFormat.Format32bppArgb))
        {
            // Paste on 32bppARGB image to get a predictable byte format to iterate over
            using (Graphics gr = Graphics.FromImage(bm))
                gr.DrawImage(image, new Rectangle(0, 0, width, height));
            // Use LockBits and Marshal.Copy to get the raw bytes and the stride (line width in bytes) out.
            BitmapData sourceData = bm.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bm.PixelFormat);
            stride = sourceData.Stride;
            imageData = new Byte[stride * bm.Height];
            Marshal.Copy(sourceData.Scan0, imageData, 0, imageData.Length);
            bm.UnlockBits(sourceData);
        }
        // Store colour frequencies in a dictionary.
        Dictionary<Color,Int32> colorFreq = new Dictionary<Color, Int32>();
        for (Int32 y = 0; y < height; y++)
        {
            // Reset offset on every line, since stride is not guaranteed to always be width * pixel size.
            Int32 inputOffs = y * stride;
            //Final offset = y * line length in bytes + x * pixel length in bytes.
            //To avoid recalculating that offset each time we just increase it with the pixel size at the end of each x iteration.
            for (Int32 x = 0; x < width; x++)
            {
                //Get colour components out. "ARGB" is actually the order in the final integer which is read as little-endian, so the real order is BGRA.
                Color col = Color.FromArgb(imageData[inputOffs + 3], imageData[inputOffs + 2], imageData[inputOffs + 1], imageData[inputOffs]);
                Color bareCol = Color.FromArgb(255, col);
                // Only look at nontransparent pixels; cut off at 127.
                if (col.A > 127)
                {
                    if (!colorFreq.ContainsKey(bareCol))
                        colorFreq.Add(bareCol, 1);
                    else
                        colorFreq[bareCol]++;
                }
                // Increase the offset by the pixel width. For 32bpp ARGB, each pixel is 4 bytes.
                inputOffs += 4;
            }
        }
        // Get the maximum value in the dictionary values
        Int32 max = colorFreq.Values.Max();
        // Get the first colour that matches that maximum.
        return colorFreq.FirstOrDefault(x => x.Value == max).Key;
        // In case you want to know if there are multiple with the exact same frequency,
        // this could be expanded to give an array with all maxima like this:
        // Color[] maxCols = colorFreq.Where(x => x.Value == max).Select(kvp => kvp.Key).ToArray();
    }
