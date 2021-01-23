    	public void GetImage()
		{
            Rectangle display1 = this.Bounds; // winforms control bounds
            // for full screen use "= Screen.GetBounds(Point.Empty);
			var bm = new Bitmap(display1.Width, display1.Height);
			//display1.DrawToBitmap(bm, display1.ClientRectangle);
			Graphics g = Graphics.FromImage(bm);
			g.CopyFromScreen(new Point(display1.Left, display1.Top), Point.Empty, display1.Size);
			var dlg = new SaveFileDialog { DefaultExt = "png", Filter = "Png Files|*.png" };
			var res = dlg.ShowDialog();
			if (res == DialogResult.OK) bm.Save(dlg.FileName, ImageFormat.Png);
		}
