    public class Level2 : IEntity
    {
        public int ID { get; set; }
        public OrgTypes Type { get { return OrgTypes.Level2; } }
        public string Name { get; set; }
        public IEntity Parent { get; set; }
        public Level1 Level1Parent {
            get { return (Level1)Parent; }
            set { Parent = value; }
        }
    }
