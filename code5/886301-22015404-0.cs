    if (File.Exists("newfilename"))
    {
        System.IO.File.Delete("newfilename");
    }
    
    System.IO.File.Move("oldfilename", "newfilename");
