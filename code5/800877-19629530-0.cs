    public interface IPetFoodChoice
    {
        FoodType preferedFoodType { get; }
    }
    public class Dog : IPetFoodChoice
    {
        public FoodType preferedFoodType { get { return FoodType.Milk; } }
    }
    public class Cat : IPetFoodChoice
    {
        public FoodType preferedFoodType { get { return FoodType.Fish; } }
    }
    public class Pet
    {
        private FoodType _foodType;
        public Pet(IPetFoodChoice sample)
        {
            _foodType = sample.preferedFoodType;
        }
    }
