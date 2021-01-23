    public class Unit
    {
        public string Name { get; set; }
        List<Group> list = new List<Group>();
        public List<Group> Contains
        {
            get { return list; }
        }
    }
