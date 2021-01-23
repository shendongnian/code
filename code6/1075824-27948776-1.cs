    public class Human {
        public string Id { get; set; }
        public string Name { get; set; }
        public Pet Pet { get; set; }
    }
    
    public class Pet {
        public string Id { get; set; }
        public string Name { get; set; }
    	public string HumanId {get; set;}
    	public virtual Human {get; set;}
    }
