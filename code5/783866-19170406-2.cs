    for (int n = 0; n < hProcessSnap.Length; n++)
    {
        // ProcessName is not Unique, there could be many matching processes
        //   and this loop will only return the last one.
        if (hProcessSnap[n].ProcessName == "test")  
            hProcess = hProcessSnap[n];
        // Id is Unique - there will be only one matching process
        if (hProcessSnap[n].Id == 123)
            hProcess = hProcessSnap[n];
    }
