    public ActionResult Create(int id)
    {
        AnimalType t = DbContext.AnimalTypes.Find(id); // get AnimalType object from database
        AnimalViewModel<Animal> model = new AnimalViewModel<Animal>()
        {
           Animal = (Animal)t.CreateInstance() // Returns a Tiger object cast to an Animal
        };
 
        return View(model);
    }
