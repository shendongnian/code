    string filename = System.IO.Path.GetTempFileName() + ".pdf"; // Makes something like "C:\Temp\blah.tmp.pdf"
    
    File.WriteAllBytes(filename, filedata);
    
    var process = Process.Start(filename);
    // Clean up our temporary file...
    process.Exited += (s,e) => System.IO.File.Delete(filename); 
