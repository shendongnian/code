     try
       {
            var dir = new DirectoryInfo(@"uploads//"+civil_case.Text);
            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
            
            //delete    
            System.IO.Directory.Delete(@"uploads//"+civil_case.Text, true);
                                
        }
        catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
