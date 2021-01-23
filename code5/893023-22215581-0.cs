    /// <summary>
    /// This class should have a method that returns price of pet food. This class should be able to handle different pet animals
    /// which as of now, is unknown
    /// </summary>
    class PetFood
    {
        public decimal GetFoodPrice(string petType)
        {
            IPetAnimal petAnimal = null;
            if (petType == "Dog")
            {
                petAnimal = new Dog();
            }
            else if (petType == "Cat")
            {
                petAnimal = new Cat();
            }
            else
            {
                MessageBox.Show("This animal is not supported yet.");
                return 0M;
            }
            return petAnimal.GetFoodPrice();
        }
    }
    interface IPetAnimal
    {
        decimal GetFoodPrice();
    }
    class Dog : IPetAnimal
    {
        public decimal GetFoodPrice()
        {
            return 10M;
        }
    }
    class Cat : IPetAnimal
    {
        public decimal GetFoodPrice()
        {
            return 5M;
        }
    }
