    var  sampleList = new HashSet<Result>(rootoject.result.Where(item
                => item.status == "approved")).ToList();
    var sampleRootObject = new RootObject();
    sampleRootObject.result = sampleList; // The setter needs to be made public
    approvedList.Add( sampleRootObject);
