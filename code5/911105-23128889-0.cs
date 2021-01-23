            var myGraph = tableA.Where(c => c.Id == id)
                .Include(c => c.childA)
                .Include(c => c.childB)
                .Include(c => c.childC)
                .AsNoTracking()
                .FirstOrDefault();
            if (myGraph != null)
            {
                myGraph.CopiedFromId = id;
                myGraph = Context.Set<TableA>().Add(myGraph);
                Context.SaveChanges();
            }
