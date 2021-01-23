    Using System.IO;
    
    public void Copy(string filePath,string DestPath)
    {
        if(File.Exists(filePath))
        {
           File.Copy(filePath,DestPath);
        }
        else
        {
           MessageBox.Show("The file doesn't exists.","Error") 
        }
    }
