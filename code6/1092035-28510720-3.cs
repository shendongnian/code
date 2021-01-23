		private void skyInTheWindow()
		{
			var bitmap = new Bitmap("C:/MyPath/Sky.jpg");  // load it once
			for (int i = 0; i < 100; i++)
			{
				// Loading sky into the window
				sky = new PictureBox();
				sky.Image = bitmap; // now all picture boxes share same image, thus less memory
				sky.SetBounds(positionX, positionY, width, height);
				this.Controls.Add(sky);
				consecutivePictures.Add(sky);
				positionX += width;
			}
		}
