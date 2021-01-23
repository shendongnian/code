    List<System.Drawing.Image> listOfSystemDrawingImage = new List<System.Drawing.Image>();
    System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    {
        int index = 0;
        foreach (var image in listOfSystemDrawingImage)
        {
            image.Save(string.Format("{0}\\Image{1}.png", dialog.SelectedPath, index), System.Drawing.Imaging.ImageFormat.Png);
            index++;
        }
    }
