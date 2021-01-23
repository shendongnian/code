    // check if there is something in the collection
    if (result != null && result.Any() && result.Count >= 1)
    {
        URL = result[1] as string;
        if (!string.IsNullOrEmpty(URL))
        {
           // continue safe ...
        }    
        else
        {
            // stop the timer... or something like this
            aTimer.Stop();
        }
    }
