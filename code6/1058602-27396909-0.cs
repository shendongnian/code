        static List<Node> BuildTree(List<Product> lst, int topID) 
        {
            var tree = Enumerable.Empty<Node>().ToList();
            if (lst == null)
            {
                return tree;
            }
            foreach (var product in lst)
            {
                if (product.ParentId == topID)
                {
                    Node node = new Node 
                    {
                        Product = product,
                        LstNodes = BuildTree(lst.Where(p => p.ParentId == product.Id).ToList(), product.Id)
                    };
                    tree.Add(node);
                }
            }
            return tree;
        }
