        public Form1()
        {
            InitializeComponent();
            Bitmap image1 = new Bitmap(@"C:\Users\Nicke Manarin\Desktop\YEeJO.png");
            BlackWhite(image1);
        }
        public void BlackWhite(Bitmap image)
        {
            PixelUtil pixelUtil = new PixelUtil(image);
            pixelUtil.LockBits();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (pixelUtil.GetPixel(x, y).GetBrightness() > 0.5)
                    {
                        pixelUtil.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        pixelUtil.SetPixel(x, y, Color.Black);
                    }
                }
            }
            pixelUtil.UnlockBits();
            pictureBox1.Image = image;
            image.Save(@"C:\Users\Nicke Manarin\Desktop\YEeJO2.png");
        }
