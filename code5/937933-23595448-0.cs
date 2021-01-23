	long size = GetFileSizeOnDisk(previewFileName);
	if(size > 1024 * 1024 * 1024)
	{
		label10.Text = (size / 1024 * 1024 * 1024F).ToString() + " Gb";
	}
	else if(size > 1024 * 1024)
	{
		label10.Text = (size / 1024 * 1024F).ToString() + " Mb";
	}
	else if(size > 1024)
	{
		label10.Text = (size / 1024F).ToString() + " Kb";
	}
	else
	{
		label10.Text = size.ToString();
	}
