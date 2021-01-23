    public class HierarchyTable {
        public HierarchyTable(HierarchyTable parent) {
            Parent = parent;
            Children = new List<HierarchyTable>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public int ParentID { get; set; }
        //Navigation Properties created by Entity Framework
        public virtual HierarchyTable Parent { get; set; }
        public virtual ICollection<HierarchyTable> Children { get; set; }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: " + ID).Append('\t');
            sb.Append("Name: " + Name).Append('\t');
            sb.Append("SortOrder: " + SortOrder).Append('\t');
            sb.Append("ParentID: " + ParentID);
            return sb.ToString();
        }
        //-----------------------------------------------------
        // Builds a hierarchical tree out of a List<HierarchyTable>
        // and copies each child row into a different 
        // List<HierarchyTable> as it is being built.
        //-----------------------------------------------------
        public static List<HierarchyTable> HierarchicalSort(ICollection<HierarchyTable> inputlist) {
            
            HierarchyTable topNode = inputlist.ElementAt(0);
            HierarchyTable current = topNode;
            HierarchyTable child = null;
            inputlist.Remove(topNode);
            List<HierarchyTable> copyList = inputlist.Take(inputlist.Count).ToList();
            List<HierarchyTable> outputList = new List<HierarchyTable>() { topNode };
            foreach (HierarchyTable rec in inputlist) {
                do {                    
                    child = GetNextNode(current, copyList);
                    if (child != null) {
                        child.Parent = current;
                        current.Children.Add(child);
                        current = child;
                        copyList.Remove(child);
                        outputList.Add(child);
                    }
                } while (child != null);
                               
                current = topNode;
            }
            return outputList;
        }
        //-----------------------------------------------------
        // Returns the first child of a sorted match on 
        // ID == ParentID. If you end up needing to sort on 
        // multiple columns or objects that don't already 
        // implement IComparer, then make your own comparer
        // class. The syntax would be:
        //
        // .OrderBy(x => x, new ComparerClass());
        //-----------------------------------------------------
        private static HierarchyTable GetNextNode(HierarchyTable current, ICollection<HierarchyTable> inputlist) {
            List<HierarchyTable> sublist = inputlist
                .Where(
                    a => a.ParentID == current.ID
                ).OrderBy(
                    x => x.SortOrder
                ).ToList();
            if(sublist.Count > 0)
                return sublist.First();
            return null;
        }
    }
