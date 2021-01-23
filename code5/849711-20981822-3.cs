        public void Run()
        {
            var bitmap = CreateRandomBitmap(new Size(64, 64));
            bitmap.Save("random.png", ImageFormat.Png);
            bitmap.Dispose();
        }
