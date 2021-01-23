        static void Main(string[] args)
        {
            
            WorkItem w1 = new WorkItem { Name = "w1" };
            WorkItem w2 = new WorkItem { Name = "w2" };
            WorkItem w3 = new WorkItem { Name = "w3" };
            ChangeSet c1 = new ChangeSet{Name = "c1", WorkItems = new List<WorkItem>{w1}};
            ChangeSet c2 = new ChangeSet{Name = "c2", WorkItems = new List<WorkItem>{w3, w2}};
            ChangeSet c3 = new ChangeSet { Name = "c3", WorkItems = new List<WorkItem> { w3 } };
            List<ChangeSet> changeSets = new List<ChangeSet>{c1, c2, c3};
            var result = changeSets
                .SelectMany(c => c.WorkItems)
                .Distinct()
                .ToDictionary(w => w,
                            w => changeSets.Where(c => c.WorkItems.Contains(w)));
            foreach (var kvp in result)
            {
                var workItem = kvp.Key;
                var changeSetsForWi = kvp.Value;
                Console.WriteLine(workItem.Name);
                foreach (var cs in changeSetsForWi)
                {
                    Console.WriteLine("  " + cs.Name);
                }
            }
