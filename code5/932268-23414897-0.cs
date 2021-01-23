      Server server = new Server();
    try
    {
        //At this point you have an empty model because you just 
        //created a new Instance of your Server class,
        //It is updating the Model with all Null values because they aren't assigned to anything
        UpdateModel(server);  <----- This is not working
         
         //Here you assign values to your model, hence why they are not null anymore 
         // Your other values aren't getting saved because they still don't have a value.         
         server.Name = "testAdd";
         server.OS = "2008 R2";
        serverRepository.Add(server);
        serverRepository.Save();
        return RedirectToAction("Details", new { id = server.ServerID });
     }
