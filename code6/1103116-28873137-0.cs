    class Program
    {
        private static List<Animal> animalList = new List<Animal>();
 
        static void Main(string[] args)
        {
            Animal animal = new Animal() { TypeOfAnimal = "Dog" };
            animal.HealthList.Add(new Health() 
                                  { 
                                      Visit = new DateTime(2014, 03, 05),
                                      Symptoms = "Herby is permanantly scratching his nose" 
                                  });
            animalList.Add(animal);
        }
    }
    public class Animal
    {
        private List<Health> healthList = new List<Health>();
        public string TypeOfAnimal { get; set; }
        public List<Health> HealthList { get { return healthList; } }
    }
    public class Health
    {
        public DateTime Visit { get; set; }
        public string Symptoms { get; set; }
    }
