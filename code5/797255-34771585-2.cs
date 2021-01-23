    var dataset = entities.processlists
             .Where(x => x.environmentID == environmentid && x.ProcessName == processname && x.RemoteIP == remoteip && x.CommandLine == commandlinepart)
             .Select(x => new { x.ServerName, x.ProcessID, x.Username })
             .ToList() /// To get data from database
             .Select(x => new PInfo()
                  { 
                       ServerName = x.ServerName, 
                       ProcessID = x.ProcessID, 
                       Username = x.Username 
                  });
