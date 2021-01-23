    /// <summary>
    /// Show a File Dialog and update a label if the dialog returns a file name.
    /// </summary>
    /// <param name="label">The label to update.</param>
    private void ShowFileDialogAndUpdateLabel(Label label)
    {
        var file = new OpenFileDialog
        {
            Title = "Browse the File",
            Filter = "PDF Files (*.PDF)|*.PDF|Images (*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG;*.TIFF)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG;*.TIFF|All files (*.*)|*.*"
        };
        if (file.ShowDialog() == DialogResult.OK)
            label.Text = Path.GetFullPath(file.FileName);
    }
    private void upload_1_Click(object sender, EventArgs e)
    {
        ShowFileDialogAndUpdateLabel(upload_label1);
    }
    private void upload_2_Click(object sender, EventArgs e)
    {
        ShowFileDialogAndUpdateLabel(upload_label2);
    }
