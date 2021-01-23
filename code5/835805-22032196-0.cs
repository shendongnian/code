    //Save image to media library
    //toShare is the stream source. 
    //Don't use using statement to get stream
    MediaLibrary library = new MediaLibrary();
    var picture = library.SavePicture("Memefy_Photo", toShare);
    //Open ShareMediaTask
    var task = new ShareMediaTask();
    task.FilePath = picture.GetPath();
    task.Show();
