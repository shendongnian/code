            var query = from p in parents
                        join c in children on p.ID equals c.ParentID into jc
                        from subchildren in jc.DefaultIfEmpty()
                        select new
                        {
                            Parent = p,
                            Subchildren = subchildren
                        } into itemData
                        group itemData by itemData.Parent into g
                        select new Item
                        {
                            ParentID = g.Key.ID,
                            Description = g.Key.Description,
                            PrimaryChildID = g.Select(_ => _.Subchildren == null ? 0 : _.Subchildren.ID).FirstOrDefault(),
                            SubDescription = g.Select(_ => _.Subchildren == null ? null : _.Subchildren.Description).FirstOrDefault(),
                            ConditionalCount = 0
                        };
