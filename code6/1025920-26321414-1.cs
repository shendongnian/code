    var stuff = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);     
        //Create the query
        IEnumerable<System.IO.FileInfo> fileQuery =
            from file in fileList
            where file.Extension == ".txt" 
            orderby file.Name
            select file;
    var list = stuff.ToList();
    list.foreach(p=>{ var filename = p.Fullname; //do something with p });
        
        // Create and execute a new query by using the previous  
        // query as a starting point. fileQuery is not  
        // executed again until the call to Last() 
        var newestFile =
            (from file in stuff
             orderby file.CreationTime
             select new { file.FullName, file.CreationTime })
            .Last();
        Console.WriteLine("\r\nThe newest .txt file is {0}. Creation time: {1}",
            newestFile.FullName, newestFile.CreationTime);
     
        
        
    
  
        
