    public class Group
    {
        List<Group> groups = new List<Group>();
        List<User> users = new List<User>();
        public int ID { get; set; }
        public int ParentGroupID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Group> Groups { get { return groups; } }
        public List<User> Users { get { return users; } }
        public override string ToString()
        {
            return string.Format("Group: ID={0}, Name={1}, Parent ID={2}, #Users={3}, #Groups={4}", ID, Name, ParentGroupID, Users.Count, Groups.Count);
        }
    }
