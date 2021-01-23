        public void Run()
        {
            using(var bitmap = CreateRandomBitmap(new Size(64, 64)))
            {
                bitmap.Save("random.png", ImageFormat.Png);
            }
        }
