    protected virtual void ReloadControlCommonProperties(System.Windows.Forms.Control control, System.Resources.ResourceManager resources)
	{
		SetProperty(control, "AccessibleDescription", resources);
		SetProperty(control, "AccessibleName", resources);
		SetProperty(control, "BackgroundImage", resources);
		SetProperty(control, "Font", resources);
		SetProperty(control, "ImeMode", resources);
		SetProperty(control, "RightToLeft", resources);
		//SetProperty(control, "Size", resources);
		// following properties are not changed for the form
		if (!(control is System.Windows.Forms.Form))
		{
			SetProperty(control, "Anchor", resources);
			SetProperty(control, "Dock", resources);
			//SetProperty(control, "Enabled", resources);
			//SetProperty(control, "Location", resources);
			SetProperty(control, "TabIndex", resources);
			//SetProperty(control, "Visible", resources);
		}
		if (control is System.Windows.Forms.ScrollableControl)
		{
			ReloadScrollableControlProperties((System.Windows.Forms.ScrollableControl)control, resources);
			if (control is System.Windows.Forms.Form)
			{
				ReloadFormProperties((System.Windows.Forms.Form)control, resources);
			}
		}
	}
