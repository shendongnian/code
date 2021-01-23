    UpdateCollection securityUpdatestoInstall = new UpdateCollection();
    
    foreach (Iupdate update in securityUpdatesList)
    {
        bool blacklisted = false;
        foreach (string kB in windowsUpdateExceptionKBList)
        { 
            if (!update.Title **contains** kB)
               {
                  blacklisted = true;
                  break;
               }
        }
        if (!blacklisted)
        {
             securityUpdatestoInstall.Add(update);
        }
     }
