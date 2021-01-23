    var dataset = entities.processlists
        .Where(x => x.environmentID == environmentid && x.ProcessName == processname && x.RemoteIP == remoteip && x.CommandLine == commandlinepart)
        .Select(x => new PInfo 
                     { 
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
