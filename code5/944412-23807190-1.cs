	// Override the OnInit method to ensure our controls are added to the edit control
	protected override void OnInit(EventArgs e)
	{
		// Some code omitted for clarity
		...
		// Reference our edit controls
		EditControl = Control as EditCustomFileSummary;
		UnifiedFile selectedFile = EditControl.SelectedFile;
		SaveButton = EditControl.FindControl("SaveButton") as ToolButton;
		
		// Hook into the save event so we can save the input from our custom controls
		SaveButton.Click += OnSaveButtonClick;
		...
		_tagsControl.Text = selectedFile.Summary.Dictionary["Tags"].ToString();
		...
		EditControl.Controls.Add(_tagsControl);
	}
