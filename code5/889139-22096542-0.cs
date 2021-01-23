    public class Dog
    {
        public string Name;
        [JsonConstructor]
        public Dog()
        {
        }
        
        public Dog(string name)
        {
            Name = name + "aaa";
        }
    }
