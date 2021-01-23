    var tag = new Tag()
       {
        Id=1
       };
    var tags = new List<Tag>();
   
    tags.Add(tag);
       {
        var t = tag; `//scope of t only accessible inside the branch.`
       }
    tags.Add(t);`//This will cause error.`
