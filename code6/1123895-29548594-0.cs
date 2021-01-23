    protected void OnBtnGenClicked (object sender, EventArgs e)
	{
		Bitmap bmp = new Bitmap(300, 300);
		using (Graphics g = Graphics.FromImage(bmp))
		{
			Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Point);
			g.Clear(Color.White);
			g.DrawString(txtMessage.Text, font, Brushes.Black, 0, 0);
		}
		bmp.Save("d:/image.png", ImageFormat.Png);
		var buffer = System.IO.File.ReadAllBytes ("d:/image.png");
		var pixbuf = new Gdk.Pixbuf (buffer);
		image1.Pixbuf = pixbuf;
	}
