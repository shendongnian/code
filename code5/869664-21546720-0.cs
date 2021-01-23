    if(File.Exists(docName))
    {
        using(var package = ..) // open file
        {
           ...  
        }
    }
    else
    {
       using(var package = ..) // create file
       {
           ...  
       }
    }
