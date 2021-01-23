    List<string> splitBytes = new List<string>();
    string byteString = "";
    foreach (var chr in rsstring)
            {
                byteString += chr;
                if (byteString.Length == 3)
                {
                    splitBytes.Add(byteString);
                    byteString = "";
                }
            }
            var pixelCount = splitBytes.Count / 3;
            var numRows = pixelCount / 4;
            var numCols = pixelCount / 4;
            System.Drawing.Bitmap map = new System.Drawing.Bitmap(numRows, numCols);
            var curPixel = 0;
            for (int x = 0; x < numRows; x++)
            {
                for (int y = 0; y < numCols; y++ )
                {
                    map.SetPixel(x, y, System.Drawing.Color.FromArgb(
                        Convert.ToInt32(splitBytes[curPixel * 3]),
                        Convert.ToInt32(splitBytes[curPixel * 3 + 1]),
                        Convert.ToInt32(splitBytes[curPixel * 3 + 2])));
                    curPixel++;
                }
            }
            //Do something with image
