        List<HierarchyTable> htable = new List<HierarchyTable>(){
            new HierarchyTable() {ID = 1, Name = "A", SortOrder = 0, ParentID = 0},
            new HierarchyTable() {ID = 2, Name = "B", SortOrder = 1, ParentID = 4},
            new HierarchyTable() {ID = 3, Name = "C", SortOrder = 2, ParentID = 1},
            new HierarchyTable() {ID = 4, Name = "D", SortOrder = 1, ParentID = 1},
            new HierarchyTable() {ID = 5, Name = "E", SortOrder = 1, ParentID = 3}
        };
        List<HierarchyTable> sorted = HierarchyTable.HierarchicalSort(htable);
        foreach (HierarchyTable ht in sorted)
            Console.WriteLine(ht);
