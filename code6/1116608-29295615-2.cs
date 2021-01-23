    namespace FruitGarden
    {
        class FruitGarden
        {
            private FruitBasket basket1; // Field
            private FruitBasket basket2; // Field
            public FruitGarden() // Constructor
            {
                 MakeFruitBaskets();
            }
            private void MakeFruitBaskets()
            {
                basket1 = new FruitBasket();
                basket2 = new FruitBasket();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                FruitGarden fruitGarden = new FruitGarden();
                // Use fruitGarden
            } 
        }
    }
