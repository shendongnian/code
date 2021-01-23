    // disguise of a concrete Factory Method implementation that creates instances of 
    // DogRepository and every time you call get you get a new instance
    class DogController : AnimalControllerBase<DogRepository>
    {
       protected override DogRepository AnimalRepository
       {
           get
           {
               return new DogRepository();
           }
       }
    }
