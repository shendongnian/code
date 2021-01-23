    Parallel.Foreach(chatLib.Friends,item=>
    {
        // This runs in parallel, do the expensive work here and NOT Inside Dispatcher
        item.Photo = chatLib.getPhoto(item);
        
        Dispatcher.BeginInvoke(()=>
        {
            // This will run on the UI thread, only do updates here
            contactWindowControl.AddContactToList(item);
        });
    });
