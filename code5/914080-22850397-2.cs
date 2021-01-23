    List<ImageInfo> images = ReadImageInfos(fileName);
    if (images.Count > 0) {
        ImageInfo image = images[0];
        fileNameTextBox.Text = image.FileName;
        descriptionTextBox.Text = image.Description;
        categoryComboBox.Text = image.Category;
        dateTakenTextBox.Text = image.Date.ToShortDateString();
        commentsTextBox.Text = image.Comments;
    }
    
