    private void PreviewFileForm_Load(object sender, EventArgs e)
    {
        this.BeginInvoke(new Action(doIt));
    }
    private async void doIt()
    {
        string fileName = Path.GetFileName(this.filePath);
        lblFileName.Text = fileName;
        richtxtboxPreview.Visible = false;
        string fileContents = await ReadFileAsync(this.filePath);
        richtxtboxPreview.Text = fileContents;
        richtxtboxPreview.Visible = true;
        spinnerLoadFile.Visible = false;
    }
