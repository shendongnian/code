    public class Group
    {
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            Group g2 = obj as Group;
            return g2 != null && g2.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return Name == null 0 : Name.GetHashCode();
        }
    }
