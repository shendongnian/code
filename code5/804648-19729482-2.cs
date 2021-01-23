	void Main()
	{
		Bitmap b = new Bitmap(@"C:\test\RKB2.bmp");
		Form f1 = new Form();
		f1.Height = (b.Height /10);
		f1.Width = (b.Width / 10);
		// size the form
		f1.Size = new Size(250, 250);
		PictureBox PB = new PictureBox();
		PB.Image = (Image)(new Bitmap(b, new Size(b.Width, b.Height)));
		PB.Size = new Size(b.Width /10, b.Height /10);
		PB.SizeMode = PictureBoxSizeMode.StretchImage;
        PB.SetBounds(0, 0, 100, 100);
		Button start = new Button();
		start.Text = "Start processing";
        start.SetBounds(100, 100, 100, 35);
		// bind the button Click event
		// The code could be also extracted to a method:
		// private void startButtonClick(object sender, EventArgs e) 
		// and binded like this: start.Click += startButtonClick;
		start.Click += (s, e) =>
		{
		   for(int y = 0; y < b.Height; y++)
			{
				for(int x = 0; x < b.Width; x++)
				{
					if(b.GetPixel(x,y).R == 0 && b.GetPixel(x,y).G == 0 && b.GetPixel(x,y).B == 0)
					{
						//color is black
					}
					if(b.GetPixel(x,y).R == 255 && b.GetPixel(x,y).G == 255 && b.GetPixel(x,y).B == 255)
					{
						//color is white
						Bitmap tes = (Bitmap)PB.Image;
						tes.SetPixel(x, y, Color.Yellow);
						PB.Image = tes;
					}
				}
			}
		};
		f1.Controls.Add(PB);
		f1.Controls.Add(start);
		f1.Show();
	}
