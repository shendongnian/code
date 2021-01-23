	public void OnSaveButtonClick(object sender, EventArgs e)
	{
		// Get a reference to the current file and the summary data
		UnifiedFile selectedFile = EditControl.SelectedFile;
		
		// Get the tags added
		selectedFile.Summary.Dictionary["Tags"]  = _tagsControl.Text;
	}
