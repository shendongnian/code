            var nodes = table.AsEnumerable();
            //var nodes = new List<TreeNode>();
            var parentId = 0;
            var countLevel = 0;
            var allNods = new List<dynamic>();
            while (nodes.Any(p => p.Field<int>("parentId") == parentId))// && countLevel < 2) 
                // countlevel< 2 only to give you the first 2 levels only...
            {
                var nodesWithLevel = nodes.Where(p => p.Field<int>("parentId") == parentId)
                            .Select(p => new { Level = parentId, Node = p });
                allNods = allNods.Concat<dynamic>(nodesWithLevel).ToList();
                parentId++;
                countLevel++;
            }
