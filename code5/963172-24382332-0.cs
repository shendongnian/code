    // name of zip file
    string filename = "myfile.zip";
    // filename of content
    string contentName = "mypage.html";
    WebClient wc = new WebClient(); 
    ZipFile zipFile = new ZipFile();
    
    zipFile.Password = item.Password;
    Stream s = wc.OpenRead(myUrl); 
    zipFile.AddeEntry(contentName, s);
    MemoryStream stream = new MemoryStream();
    zipFile.Save(stream);
    zipFile.Dispose(); // could use using instead
    s.Dispose(); // could use using instead....
    stream.Seek(0, SeekOrigin.Begin);
    return File(stream, "application/zip", fileName);
