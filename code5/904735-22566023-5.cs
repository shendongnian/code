    public class AnimalViewModel<T> where T : Animal
    {
        public T Animal { get; set; }
        
        public AnimalViewModel(T animal) 
        {
             Animal = animal;
        }
    }
    public ActionResult Create(int id)
    {
        AnimalType t = DbContext.AnimalTypes.Find(id); // get AnimalType object from database
        Animal animal = (Animal)t.CreateInstance();
        var animalViewModel =  
            Activator.CreateInstance(typeof(AnimalViewModel<>).MakeGenericType(animal.GetType()),
                                     animal)
 
        return View(animalViewModel);
    }
