    private void ShowRandomImages()
    {
        List<int> selectedImages = new List<int>();
        foreach (var pictureBox in pictureBoxes)
        {
            if (filesToShow != null && !filesToShow.Any())
            {
                filesToShow = GetFilesToShow();
            }
            if (filesToShow != null && filesToShow.Any()) // If any files then allow the code to delete the shown images
            {
                int index = -1;
                if (filesToShow.Count >= pictureBoxes.Count)
                {
                    bool bOk = false;
                    while( !bOk )
                    { 
                        index = random.Next(0, filesToShow.Count);
                        bOk = selectedImages.IndexOf(index) == -1;
                    }
                }
                else
                {
                    index = random.Next(0, filesToShow.Count);
                }
                selectedImages.Add(index);
                string fileToShow = filesToShow[index];
                pictureBox.ImageLocation = filesToShow[index];
                filesToShow.RemoveAt(index);
            }
        }
    }
