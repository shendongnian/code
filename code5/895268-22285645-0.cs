    System.IO.Compression.ZipStorer zip;
    zip = System.IO.Compression.ZipStorer.Open(strZipFilePath, FileAccess.Write);
    zip.EncodeUTF8 = true;
    
    string path = "C:\\MyRootFolder\\";
    string[] arrFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
    foreach (var item in arrFiles)
    {
         string newPath = item.Replace(path, "");
         zip.AddFile(System.IO.Compression.ZipStorer.Compression.Deflate,
                    item, newPath, "");
    }
