    //Assume user types .txt into textbox
    string fileExtension = "*" + textbox1.Text;
    
    string[] txtFiles = Directory.GetFiles("Source Path", fileExtension);
    
    foreach (var item in txtFiles)
    {
       File.Move(item, Path.Combine("Destination Directory", Path.GetFileName(item)));
    }
