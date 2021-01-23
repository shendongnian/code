    public class Animal
    {
        public string Name { get; set; }
    }
    
    public class Elephant : Animal {}
    public class Emu : Animal {}
    public class Hovecraft {}
    
    public class Test
    {
        private List<Animal> animals = new List<Animal>();
    
        private void AddToZoo<T>(string name)
            where T : Animal, new()
        {
            var animal = new T();
            animal.Name = name;
            this.animals.Add(animal);
        }
    
        public void PopulateZoo()
        {
            this.AddToZoo<Elephant>("Ellie");
            this.AddToZoo<Enu>("Erik");
            this.AddToZoo<Hovercraft>("Whatever");  // Compiler error
        }
    }
