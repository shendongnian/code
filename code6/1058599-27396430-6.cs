    class Node<T>
    {
        public T Item { get; set; }
        public List<Node<T>> LstNodes  { get; set; }
    }
    
    List<Node<T>> GetNodes<T>(List<T> lst, Func<T, int> idSelector, Func<T, int> parentIdSelector, int parentId = 0)
    {
        var childProducts = lst.Where(x=>parentIdSelector(x) == parentId);
        return childProducts
               .Select(x=> new Node<T> { Item = x, LstNodes = GetNodes<T>(lst, idSelector(x))})
               .ToList();
    }
    GetNodes<Product>(lst, x=>x.id, x=>x.parentId);
