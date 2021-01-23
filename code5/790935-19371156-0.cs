    private string open(string oldFile)
        {
            OpenFileDialog newOpen = new OpenFileDialog();
            if (!string.IsNullOrEmpty(oldFile))
            {
              newOpen.InitialDirectory = Path.GetDirectoryName(oldFile);
              newOpen.FileName = Path.GetFileName(oldFile);
            }
            
            newOpen.Filter = "eXtensible Markup Language File  (*.xml) |*.xml"; //Optional filter
            DialogResult result = newOpen.ShowDialog();
            if(result == DialogResult.OK) {
                  return newOpen.FileName;
            }
            
            return string.Empty;
        }
