    var ns = clientNode.GetDefaultNamespace();
    ClientTbl ClientData = clientNode.Select(x => new ClientTbl
        {        
            ClientCode = (string)x.Elements(ns + "ClntCde").FirstOrDefault(),
            Title = (string)x.Elements(ns + "Title").FirstOrDefault(),                                                            
        }
    ).First();
