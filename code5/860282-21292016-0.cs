    public class FruitBasket {
        public FruitBasket() {
            _basket = new List<IFruit>();
        }
        public List<IFruit> Fruits {
            get { return _basket; }
        } 
        public AddFruit(IFruit fruit) {
            _basket.Add(fruit);
        }
        private readonly List<IFruit> _basket 
    }
