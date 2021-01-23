    interface IAnimal {
       void MakeNoise();
       FoodType FavoriteFood { get; }
    }
    public sealed class Dog : IAnimal {
        public void MakeNoise() { Console.WriteLine("Woof woof"); }
        public FoodType FavoriteFood { get { return FoodType.DogFood; } }
    }
    public sealed class Fox : IAnimal {
        public void MakeNoise() { Console.WriteLine("What does the fox say?"); }
        public FoodType FavoriteFood { get { return FoodType.WhatTheFoxEats; } }
    }
