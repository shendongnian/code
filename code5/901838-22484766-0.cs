    QueueUserWorkItem(()=>
    {
        // code that generates the image
        var img = GenerateImage();
        // set image to PictureBox via SynchronizationContext of the UI-Thread
        formSyncContext.Send(()=> pb.Image = img);
    }
