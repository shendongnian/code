    public partial class Location
    {
        public Location()
        {
            this.AttributeTypes = new List<LocationAttribute>();
        }
        public Location(int campusId, string code)
            : this()
        {
            CampusId = campusId; Code = code;
        }
        public int Id { get; set; }
        public int CampusId { get; set; }
        public string Code { get; set; }
        public virtual ICollection<LocationAttribute> AttributeTypes { get; set; }
    }
    public partial class LocationAttribute
    {
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public int AttributeTypeId { get; set; }
    }
    public partial class AttributeType
    {
        public int AttributeTypeId { get; set; }
        public string AttributeTypeName { get; set; }
    }
