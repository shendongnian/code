    class Test
    {
        private static IEnumerable<Den> Dens()
        {
            var dens = new List<Den>
            {
                new Den
                {
                    DenID = 1,
                    DenName = "GamePark",
                    FoodList = new Collection<Food>()
                    {
                        new Food
                        {
                            FoodID = 1,
                            FoodName = "Veg",
                            AnimalList = new Collection<Animal>
                            {
                                new Animal
                                {
                                    AnimalID = 234,
                                    AnimalName = "Zebra",
                                    FoodList = new Collection<Food>{new Food {FoodID = 1, FoodName = "Veg"} }
                                },
                                new Animal
                                {
                                    AnimalID = 125,
                                    AnimalName = "Buffalo",
                                    FoodList = new Collection<Food>{new Food {FoodID = 1, FoodName = "Veg"} }
                                }
                            }
                        },
                        new Food
                        {
                            FoodID = 2,
                            FoodName = "Meat",
                            AnimalList = new Collection<Animal>
                            {
                                new Animal
                                {
                                    AnimalID = 003,
                                    AnimalName = "Leopard",
                                    FoodList = new Collection<Food>{new Food {FoodID = 2, FoodName = "Meat"} }
                                },
                                new Animal
                                {
                                    AnimalID = 001,
                                    AnimalName = "Lion",
                                    FoodList = new Collection<Food>{new Food {FoodID = 2, FoodName = "Meat"} }
                                }
                            }
                        }
                    }
                }
            };
            return dens;
        }
        public static IEnumerable<Animal> GetAnimalsWithFoodsInDen(int denId)
        {
            var den = Dens().FirstOrDefault(x => x.DenID == denId);
            var animals = new List<Animal>();
            if (den != null)
            {
                var foods = den.FoodList;
                if (foods != null)
                {
                    animals = foods.ToList().Aggregate(animals, (current, food) => current.Union(food.AnimalList).ToList());
                }
            }
            return animals;
        }
        static void Main(string[] args)
        {
            var result = GetAnimalsWithFoodsInDen(1);
            foreach (var a in result)
            {
                Console.WriteLine(a.AnimalName);
            }
            Console.ReadLine();
        }
    }
