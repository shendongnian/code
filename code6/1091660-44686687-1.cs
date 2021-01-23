    public class EntityOne
    {
        [Key]
        public int EntityOneId { get; set; }
        public EntityTwo EntityTwo => EntityTwoNavigation?.FirstOrDefault();
        public ICollection<EntityTwo> EntityTwoNavigation { get; set; }
    }
    
    public class EntityTwo
    {
        [Key]
        public int EntityTwoId { get; set; }
        public int EntityOneId { get; set; }
        [ForeignKey("EntityOneId")]
        public EntityOne EntityOne { get; set; }
    }
