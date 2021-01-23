    try{
            string path = string.format(@"uploads\{0}",civil_case.Text);
            var dir = new DirectoryInfo(path ; //change the // to \
            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
            dir.Delete(true); //or dir.Delete();
        }
        catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
