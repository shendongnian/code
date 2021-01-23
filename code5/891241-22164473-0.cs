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
