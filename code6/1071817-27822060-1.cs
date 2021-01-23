    public class FruitViewModel
    {
        public IEnumerable<Fruit> Fruits { get; set; }
        public FruitViewModel(IEnumerable<Fruit> fruit)
        {
            Fruits = fruits
        }
    }
