	private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
	{
		Point mousePosition = new Point(e.X, e.Y);
		if (e.Button == MouseButtons.Left)
		{
			// This resizeMode, moveMode and other booleans
			// are set in the MouseUp event
			if (resizeBottomLeft)
			{
				// Top and Right should remain static!
				newCropRect.X = mousePosition.X;
				newCropRect.Y = currentCropRect.Y;
				newCropRect.Width = currentCropRect.Right - mousePosition.X;
				newCropRect.Height = mousePosition.Y - newCropRect.Top;
				if (newCropRect.X > newCropRect.Right)
				{
					newCropRect.Offset(cropBoxWidth, 0);
					if (newCropRect.Right > ClientRectangle.Width)
						newCropRect.Width = ClientRectangle.Width - newCropRect.X;
				}
				if (newCropRect.Y > newCropRect.Bottom)
				{
					newCropRect.Offset(0, -cropBoxHeight);
					if (newCropRect.Y < 0)
						newCropRect.Y = 0;
				}
				// Aspect Ratio + Positioning
				if (newCropRect.Width > newCropRect.Height)
				{
					newCropRect.Height = (int)(newCropRect.Width / ASPECT_RATIO);
				}
				else
				{
					int newWidth = (int)(newCropRect.Height * ASPECT_RATIO);
					newCropRect.X = newCropRect.Right - newWidth;
					newCropRect.Width = newWidth;
				}
			}
			else if (resizeTopRight)
			{
				// Bottom and Left should remain static!
				newCropRect.X = oldCropRect.X;
				newCropRect.Y = mousePosition.Y;
				newCropRect.Width = mousePosition.X - newCropRect.Left;
				newCropRect.Height = oldCropRect.Bottom - mousePosition.Y;
				if (newCropRect.X > newCropRect.Right)
				{
					newCropRect.Offset(-cropBoxWidth, 0);
					if (newCropRect.X < 0)
						newCropRect.X = 0;
				}
				if (newCropRect.Y > newCropRect.Bottom)
				{
					newCropRect.Offset(0, cropBoxHeight);
					if (newCropRect.Bottom > ClientRectangle.Height)
						newCropRect.Y = ClientRectangle.Height - newCropRect.Height;
				}
				// Aspect Ratio + Positioning
				if (newCropRect.Width > newCropRect.Height)
				{
					int newHeight = (int)(newCropRect.Width / ASPECT_RATIO);
					newCropRect.Y = newCropRect.Bottom - newHeight;
					newCropRect.Height = newHeight;
				}
				else
				{
					int newWidth = (int)(newCropRect.Height * ASPECT_RATIO);
					newCropRect.Width = newWidth;
				}
			}
			else if (moveMode) //Moving the rectangle
			{
				newMousePosition = mousePosition;
				int dx = newMousePosition.X - oldMousePosition.X;
				int dy = newMousePosition.Y - oldMousePosition.Y;
				currentCropRect.Offset(dx, dy);
				newCropRect = currentCropRect;
				oldMousePosition = newMousePosition;
			}
			if (resizeMode || moveMode)
			{
				oldCropRect = currentCropRect = newCropRect;
				// Set the new position of the grips
				AdjustGrips();
				pictureBox1.Invalidate();
				pictureBox1.Update();
			}
		}
	}
