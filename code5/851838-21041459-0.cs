    public void NewFolder()
    {
        try
        {
            string folderName = Path.Combine(txtOutputFileEn.Text, txtNamaFile.Text);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            else
            {
                for (int x = 0; x < 50; x++)
                {
                    string tempFolder = folderName + x.ToString().PadLeft(3, '0');
                    if (!Directory.Exists(tempFolder))
                    {
                        Directory.CreateDirectory(tempFolder);
                        MessageBox.Show(tempFolder);
                        break;
                    }
                }
            }
        }
        catch (IOException ex)
        {
            MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
        
