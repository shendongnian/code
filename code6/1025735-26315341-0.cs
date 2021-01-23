       var duplicateIPConnections = connectionsList.OrderBy(x => x.IP)
                       .GroupBy(x => x.IP)
                       .Select(g => new
                       {
                           Type = g.Key,
                           Sites = g.Select(obj => new
                           {
                               obj.IP,
                               obj.Name
                           })
                       });
