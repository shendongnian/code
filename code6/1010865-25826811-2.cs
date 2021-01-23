    interface IAnimal
    {
        void FavFood();
    }
    
    public sealed class Dog : IAnimal
    {
        public void FavFood() { Console.WriteLine("Me loves  dog food. Woof woof."); }
    }
    
    public sealed class Goat : IAnimal
    {
        public void FavFood() { Console.WriteLine("Me loves goat food. myaaa.."); }
    }
  
    public static class FoodFactory
    {
        public static void Create(IAnimal animal)
        {
            animal.FavFood();
        }
    }
