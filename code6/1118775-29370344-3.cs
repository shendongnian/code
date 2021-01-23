    public class AnimalFactory
        {
            public IAnimal GetDog()
            {
                return (IAnimal) new Dog();
            }
            
            public IAnimal GetCat()
            {
                return (IAnimal) new Cat();
            }
    
        }
