    public class Dog
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set;}
        public Owner Owner { get; set; } // the navigation property
    }
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        // another navigation property
        // all the dogs that are related or owned by this specific owner
        public ICollection<Dog> DogList { get; set; } 
        public ICollection<Cat> CatList { get; set; }
    }
