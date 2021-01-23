    public class Employee : IHierarchyData
    {
        public EmployeeCollection ChildOrg { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public IHierarchicalEnumerable GetChildren()
        {
            return ChildOrg as IHierarchicalEnumerable;
        }
        public System.Web.UI.IHierarchyData GetParent()
        {
            return null;
        }
        public bool HasChildren
        {
            get { return ((this.ChildOrg != null) && (this.ChildOrg.Count > 0)); }
        }
        public object Item
        {
            get { return this; }
        }
        public string Path
        {
            get { return this.id; }
        }
        public string Type
        {
            get { return this.GetType().ToString(); }
        }
    }
