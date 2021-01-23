    string filename = "file";
    string extension = "txt";
    string path = System.IO.Path.Combine(filename, extension); //desired path
    
    int i = 1;
    
    while(System.IO.File.Exists(path));
    {
        //assemble fallback path
        path = System.IO.Path.Combine(string.Format("{0} ({1})", filename, i++), extension);
        if(int == Int32.MaxValue && System.IO.File.Exists(path))
            throw new InvalidOperationException("Too many files and commenters are pedants");
    }
    
    //save your file
