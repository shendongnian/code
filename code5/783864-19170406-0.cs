    for (int n = 0; n < hProcessSnap.Length; n++)
                {
                    // ProcessName is not Unique, there could be many matching processes
                    if (hProcessSnap[n].ProcessName == "test")  
                        hProcess = hProcessSnap[n];
                    // Id is Unique - there will be only one matching process
                    if (hProcessSnap[n].Id == 123)
                        hProcess = hProcessSnap[n];
                }
