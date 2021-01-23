        foreach (var collection in collections)
        {
            var node = new DynamicNode
            {
                Title = collection.collection,
                Controller = "Collections",
                Action = "Index",
                // Specify the node you want this node nested under
                ParentKey = "nodeCollections", 
                ChangeFrequency = ChangeFrequency.Weekly
            };
            node.RouteValues.Add("seocollection", collection.seoCollection);
            yield return node;
        }
        ////Get Categories Nodes
        // Create a node for each category 
        foreach (var category in categories)
        {
            var node = new DynamicNode
            {
                //Key = category.category,
                Title = category.category,
                Controller = "Products",
                Action = "Index",
                // Specify the node you want this node nested under
                ParentKey = "nodeCategories",
                ChangeFrequency = ChangeFrequency.Weekly
            };
            node.RouteValues.Add("seocategory", category.seocategory);
            yield return node2;
        }
