    void watcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        Debug.WriteLine("my device is inserted..");
        // Notice how we check the event handler for null.
        // If you don't, it could throw a NullReferenceException.
        // Irritating, but easy to debug.. Usually..
        if (Inserted != null)
            Inserted("my device"); // Or whatever parameters you need.
    }
