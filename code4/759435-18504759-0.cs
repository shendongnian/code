    string filename = "file";
    string extension = "txt";
    string path = System.IO.Path.Combine(filename, extension); //desired path
    
    int i = 1;
    
    while(System.IO.File.Exists(path));
    {
        //assemble fallback path
        path = System.IO.Path.Combine(string.Format("{0} ({1})", filename, i++), extension);
    }
    
    //save your file
