    public void DeleteFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                return;
            // get the directory with the specific name
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            try
            {
                foreach (FileInfo fi in dir.GetFiles())
                    fi.Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
