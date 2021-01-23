    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return "[" + Name + ", " + Age + "]";
        }
    }
	
	public class Zoo
    {
        public List<Animal> Animals { get; set; }
        public Zoo()
        {
            Animals = new List<Animal>();
        }
        // Pass all parameters
        public void AddAnimal(string name, int age)
        {
            Animal animal = new Animal
            {
                Name = name,
                Age = age
            };
            Animals.Add(animal);
        }
        // -> pseudo code <- Create the parameter reference automated -> pseudo code <-
        public void AddAnimal(params object[] animalProperties)
        {
            Animal animal = new Animal
            {
                Name = animalProperties[0] as string,
                Age = (animalProperties[1] as int?).Value
            };
            Animals.Add(animal);
        }
    }
	
	public class Example
    {
        public void Run()
        {
            Zoo zoo = new Zoo();
            zoo.AddAnimal("Tom", 8);
            foreach (Animal a in zoo.Animals)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
