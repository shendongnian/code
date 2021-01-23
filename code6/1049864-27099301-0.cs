    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int ParentID { get; set; }
        public Group Parent { get; set; }
    }
