    public interface IEating<in T> where T : IFood {
        void Eat(T food);
    }
    public class Lion : IEating<IMeat>, IEating<IFood> {
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Nitrogen { get; set; }
        public void Eat(IMeat food) {
            Protein = food.Protein;
            Carbohydrate = food.Carbohydrate;
            Nitrogen = food.Nitrogen;
        }
        public void Eat(IFood food) {
            var meat = food as IMeat;
            if (meat == null) return;
            Eat(meat);
        }
    }
    public class Sheep : IEating<IVegetable>, IEating<IFood> {
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Vitamin { get; set; }
        public void Eat(IVegetable food) {
            Protein = food.Protein;
            Carbohydrate = food.Carbohydrate;
            Vitamin = food.Vitamin;
        }
        public void Eat(IFood food) {
            var vegetable = food as IVegetable;
            if (vegetable == null) return;
            Eat(vegetable);
        }
    }
