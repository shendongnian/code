    List<Node> GetNodes(List<Product> lst, int parentId = 0)
    {
        var childProducts = lst.Where(x=>x.ParentId == parentId);
        return childProducts
               .Select(x=> new Node { Product = x, LstNodes = GetNodes(lst, x.Id)}
               .ToList();
    }
