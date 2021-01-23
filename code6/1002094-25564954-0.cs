	if (panelExtendedLayout.Visible)
	{
		panelSimpleLayout.Visible = false;
		panelExtendedLayout.Visible = true;
		panelExtendedLayout.Controls.Remove(axWindowsMediaPlayer);
		panelSimpleLayout.Controls.Add(axWindowsMediaPlayer);
	}
	else
	{
		panelSimpleLayout.Visible = true;
		panelExtendedLayout.Visible = false;
		panelExtendedLayout.Controls.Remove(axWindowsMediaPlayer);
		panelSimpleLayout.Controls.Add(axWindowsMediaPlayer);
	}
