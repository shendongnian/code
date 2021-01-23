            int x = 0, y = 0;
            ///Get Data
            Bitmap myBitmap = new Bitmap("mold.jpg");
            Color[,] pixelData = new Color[myBitmap.Width, myBitmap.Height];
            for (y = 0; y < myBitmap.Height; y++)
                for (x = 0; x < myBitmap.Width; x++)
                    pixelData[x,y] = myBitmap.GetPixel(x, y);
            ///Randomly convert 3 pixels to black
            Random rand = new Random();
            List<Point> Used = new List<Point>();  
            for (int i = 0; i < 300; i++)
            {
                x = rand.Next(0, myBitmap.Width);
                y = rand.Next(0, myBitmap.Height);
                //Ensure we use 300 distinct numbers
                while (Used.Contains(new Point(x,y)))
                {
                    x = rand.Next(0, myBitmap.Width);
                    y = rand.Next(0, myBitmap.Height);
                }
                Used.Add(new Point(x, y));
                pixelData[x, y] = Color.Black;
            }
            ///Save the new image
            for (y = 0; y < myBitmap.Height; y++)
                for (x = 0; x < myBitmap.Width; x++)
                    myBitmap.SetPixel(x, y, pixelData[x, y]);
            myBitmap.Save("mold2.jpg");
