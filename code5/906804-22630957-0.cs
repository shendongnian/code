     decimal _imagementSize = 0;
     string _imageName = "";
     string _imageType = "";
     Binary _image;
     OpenFileDialog dialog=new OpenFileDialog();
     private void btnSaveImage_Click(object sender, RoutedEventArgs e)
     {
       dialog.Multiselect = false;
       dialog.Filter = "All Files | *.*";
       if (dialog.ShowDialog() == true)
       {
           bool fileExist = dialog.File.Exists;
           if (fileExist)
           {       
              UploadFile();    
           }                  
       }
     }
     private void UploadFile()
     {
        double fileLength = 0;
        var stream = dialog.File.OpenRead();
        var bnr = new BinaryReader(stream);
        byte[] buffer = new byte[stream.Length + 1];
        buffer = bnr.ReadBytes((int)stream.Length);
        fileLength = stream.Length;
        _imageName = dialog.File.Name;
        _imageType = dialog.File.Extension;
        _imageSize = (decimal)(fileLength / 1024);
        _image = new Binary() { Bytes = buffer };         
     }
    
