	private void Form2_Load(object sender, EventArgs e)
	{
		string[] files = Directory.GetFiles(Form1.programdir + "\\card_images", "*", SearchOption.TopDirectoryOnly);
		foreach (var filename in files)
		{
			Bitmap bmp = null;
			try
			{
				bmp = new Bitmap(filename);
			}
			catch (Exception e)
			{
				// remove this if you don't want to see the exception message
				MessageBox.Show(e.Message);
				continue;
			}
			var card = new PictureBox();
			card.BackgroundImage = bmp;
			card.Padding = new Padding(0);
			card.BackgroundImageLayout = ImageLayout.Stretch;
			card.MouseDown += new MouseEventHandler(card_click);
			card.Size = new Size((int)(this.ClientSize.Width / 2) - 15, images.Height);
			images.Controls.Add(card);
		}
	}
