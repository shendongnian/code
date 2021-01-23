    System.Collections.Specialized.StringCollection stC = new System.Collections.Specialized.StringCollection();
    stC.AddRange(System.IO.Directory.GetDirectories(tempPath));
    stC.AddRange(System.IO.Directory.GetFiles(tempPath));
    
    //Clipboard.Clear(); //No need to Call this.
    
    //>Call from an STA thread
    Thread t = new Thread(() => { 
                                  Clipboard.SetFileDropList(stC); 
                                });
    t.SetApartmentState(ApartmentState.STA);
    t.Start();
