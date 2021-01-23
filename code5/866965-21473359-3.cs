        var nodes = new List<Node>
    	{
    		new Node{ Id = 1 },
    		new Node{ Id = 2 },
    		new Node{ Id = 3, ParentId = 1 },
    		new Node{ Id = 4, ParentId = 1 },
    		new Node{ Id = 5, ParentId = 3 }
    	};
    	
    	foreach (var item in nodes)
    	{
    		item.Children = nodes.Where(x => x.ParentId.HasValue && x.ParentId == item.Id).ToList();
    	}
    	
    	var tree = nodes.Where(x => !x.ParentId.HasValue).ToList();
