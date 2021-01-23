    public interface IEating<T> where T : IFood {
        void Eat(T food);
    }
    public class Lion : IEating<IMeat> {
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Nitrogen { get; set; }
        public void Eat(IMeat food) {
            Protein = food.Protein;
            Carbohydrate = food.Carbohydrate;
            Nitrogen = food.Nitrogen;
        }
    }
    public class Sheep : IEating<IVegetable> {
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Vitamin { get; set; }
        public void Eat(IVegetable food) {
            Protein = food.Protein;
            Carbohydrate = food.Carbohydrate;
            Vitamin = food.Vitamin;
        }
    }
