                      ServerName = x.ServerName, 
                      ProcessID = x.ProcessID, 
                      UserName = x.Username 
                 }) AsEnumerable().
               Select(y => new PInfo
               {
                   ServerName = y.ServerName,
                   ProcessID = y.ProcessID,
                   UserName = y.UserName 
               }).ToList();
