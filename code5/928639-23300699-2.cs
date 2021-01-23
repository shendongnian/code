    try{
            string path = String.format(@"uploads\{0}",civil_case.Text);
            var dir = new DirectoryInfo(path) ; //change the // to \
            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
            dir.Delete();
        }
        catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
