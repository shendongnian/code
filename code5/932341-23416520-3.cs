    public class Unit
    {
        public string Name { get; set; }
        public List<Group> Groups{ get; set; }
        public Unit()
        {
            Groups=new List<Group>();
        }
    }
