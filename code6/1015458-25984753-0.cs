		private Bitmap bmp2 = new Bitmap(Image.FromFile(@"e:\temp\temp\yourGIF.gif"));
		public Form1()
		{
			InitializeComponent();
			pictureBox1.Image = bmp2;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			var sz = bmp2.Size;
			for(int x= 0; x<sz.Width; x++)
			{
				for(int y=0; y<sz.Height; y++)
				{
					bmp2.SetPixel(x, y, Color.Yellow);
				}
			}
			pictureBox1.Refresh();
		}
