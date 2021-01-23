    public class Venue : BaseObject, IBaseObject
    {
        public (int/guid/or other type if you want) OwnerId{get;set;}
        [Required]
        public virtual User Owner { get; set; }
    
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
