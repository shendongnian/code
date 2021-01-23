    public class Human {
        [Key]
    	public int HumanId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
    
    public class Pet {
    	[Key]
        public int PetId { get; set; }
        public string Name { get; set; }
    	public int HumanId {get; set;}
    	public virtual Human Owner {get; set;}
    }
