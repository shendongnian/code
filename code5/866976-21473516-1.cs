            var items = new List<Item>();
            items.Add(new Item { Id = 1, ParentId = null });
            items.Add(new Item { Id = 2, ParentId = 1 });
            items.Add(new Item { Id = 3, ParentId = 1 });
            items.Add(new Item { Id = 4, ParentId = 3 });
            items.Add(new Item { Id = 5, ParentId = 3 });
            var itemsWithChildren = items.Select(a =>
                new ItemWithChildren { Item = a }).ToList();
            itemsWithChildren.ForEach(a =>
                    a.Children = itemsWithChildren.Where(b => 
                        b.Item.ParentId == a.Item.Id).ToList());
            var root = itemsWithChildren.Single(a => !a.Item.ParentId.HasValue);
            Console.WriteLine(root.Item.Id);
            Console.WriteLine(root.Children.Count);
            Console.WriteLine(root.Children[0].Children.Count);
            Console.WriteLine(root.Children[1].Children.Count);
 
