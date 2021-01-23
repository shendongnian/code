    public class Entity
    {
        #region Constructors
    
        public Entity() : this(DateTime.Now, DateTime.Now, default(int)) { }
    
        public Entity(DateTime creationDate, DateTime updateDate, int id)
        {
            DateCreated = creationDate;
            DateUpdated = updateDate;
            Id = id
        }
    
        #endregion
    
        #region Properties
    
        [Key]
        [Required]
        [Column(Order= 0)]
        public int Id { get; private set; }
    
        [Required]
        [Column(Order = 998)]
        public DateTime DateCreated { get; private set; }
    
        [Required]
        [Column(Order = 999)]
        public DateTime DateUpdated { get; internal set; }
    
        #endregion
    }
