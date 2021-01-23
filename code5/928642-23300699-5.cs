    try{
            
            var dir = new DirectoryInfo(@"uploads\") ; //change the // to \
             foreach (DirectoryInfo subDir in dir)
            {
               If(subDir.FullName.Contains(civil_case.Text))
                 {
                   subDir.Attributes = subDir.Attributes & ~FileAttributes.ReadOnly;
                    subDir.Delete(true);
        
                 }
            }
                 }
        catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
