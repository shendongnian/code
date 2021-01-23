        public class AbstractFarmer
        {
            protected FarmAnimal animal;
            public string GetProduct()
            {
                return animal.GetFood;
            }
        }
    
        public class CowFarmer : AbstractFarmer
        {
            public CowFarmer()
            {
                animal = new Cow();
            }
        }
    
        public class ChickenFarmer : AbstractFarmer
        {
            public ChickenFarmer()
            {
                animal = new Chicken();
            }
        }
