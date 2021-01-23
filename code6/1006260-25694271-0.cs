    private void HandleEvents()
    {
        while (!queue.IsCompleted)
        {
            string someValue = queue.Take();
            //Do stuff
        }
    }
