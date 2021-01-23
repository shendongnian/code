	if (item.ImageIndex != -1)
	{
		imageList.Draw(ea.Graphics, bounds.Left, bounds.Top, item.ImageIndex);
		
		ea.Graphics.DrawString(item.Text, ea.Font, new
			SolidBrush(ea.ForeColor), bounds.Left+imageSize.Width, bounds.Top);
	}
