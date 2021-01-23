    oldList.GroupBy(x => new { x.Name, x.AssignedArea })
           .Select(g => g.Count() == 1
               ? new Entity(g.Key.Name, g.Key.AssignedArea, g.Single())
               : new Entity(g.Key.Name, g.Key.AssignedArea, "All programs")
           );
