    class MyGroup {
        public string Name { get; set; }
        public int Count { get; set; }
    }
    var supervisorSummary = Persons.GroupBy(p => p.SupervisorName)
                               .Select(group => new MyGroup { Name = group.Key, 
                                                      Count = group.Count() })
                               .OrderBy(x => x.Name).ToList();
