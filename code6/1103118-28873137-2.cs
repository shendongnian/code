    class Program
    {
        private static List<Animal> animalList = new List<Animal>();
 
        static void Main(string[] args)
        {
            Animal animal = new Animal() { TypeOfAnimal = "Dog" };
            // created a new animal
            
            animal.HealthList.Add(new Health() 
                                  { 
                                      Visit = new DateTime(2014, 03, 05),
                                      Symptoms = "Herby is permanantly scratching his nose" 
                                  });
            // added a new instance of Health to its HealthList
            // if you allready have a List<Health> the you can call
            // animal.HealthList.AddRange(theList); 
            // works as well with any other IEnumerable<Health>
            animalList.Add(animal);
        }
    }
    public class Animal
    {
        private List<Health> healthList = new List<Health>(); 
        // the default accessmodifier for a classmember is private
        // you can write it too so you better understand what's going on
        public string TypeOfAnimal { get; set; }
        public List<Health> HealthList { get { return healthList; } }
        // add a readonly property for the list so you can access it from outside the class
    }
    public class Health 
    // change this name for "HealthList" is missleading you
    // because it would imply that it is a collection
    {
        public DateTime Visit { get; set; }
        public string Symptoms { get; set; }
    }
