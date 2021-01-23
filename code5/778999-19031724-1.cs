    var ns = clientNode.GetDefaultNamespace();
    ClientTbl ClientData = clientNode.Select(x => new ClientTbl
        {        
            ClientCode = (string)x.Element(ns + "ClntCde") ?? string.Empty,
            Title = (string)x.Element(ns + "Title") ?? string.Empty,
        }
    ).First();
