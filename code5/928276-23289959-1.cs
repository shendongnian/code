    System.Threading.Tasks.Parallel.For(0, pageNodes.Count, index =>
    {
        string node = pageNodes[index];
        
        try
        {
            string temp = DoSomeComplicatedModificationOnNode(node);
            if (temp.ToLower().Contains(path))
                pages.Add(MyPage(index, node.Title));
        }
        catch (Exception)
        {
    		throw;
        }
    });
