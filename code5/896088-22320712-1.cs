    public class MembershipType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public MembershipType(BO.MembershipType MembershipType)
        {
            this.ID = MembershipType.ID;
            this.Name = MembershipType.Name;
        }
        public MembershipType()
        {
        }
    }
