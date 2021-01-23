    var pages = new ConcurrentBag<string>();
    Parallel.ForEach(pageNodes, node =>
    {
        try
        {
            string temp = DoSomeComplicatedModificationOnNode(node);
            if (temp.ToLower().Contains(path))
                pages.Add(node.Title);
        }
        catch (Exception)
        {
    		throw;
        }
    });
