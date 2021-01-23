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
    
        private void AddToZoo<TAnimal>(string name)
            where TAnimal : Animal, new()
        {
            var animal = new TAnimal();
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
