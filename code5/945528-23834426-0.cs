    var newList = Result.ToList(); //get a in-memory list
    foreach (var item in newList) //modify in-memory list
    {
            if (LookForME.Any(fs => item.LinkUrl.Contains(fs)))
            {
                item.LinkUrl = ServerPath + "/" + item.LinkUrl;   
                // works great until its time to return the updated Results list                 
            }
               // something here to update results with new value?
    }
    return newList;  
