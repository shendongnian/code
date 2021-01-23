    // A shared collection
    List<string> paths = new List<string>();
    // Fill this collection with your fixed set.
    IEnumerator<T> e = paths.GetEnumerator();
    // Now create all threads and use e as the parameter. Now all threads have the same enumerator.
    // Inside each thread you can do this:
    while(true)
    {    
        string path;
        lock(e)
        {
            if (!e.MoveNext())
                return; // Exit the thread.
            path = e.Current;
        }
        // From here, open the file, read the image, process it, etc.
    }
