    public class Lion : IEating
    {
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Nitrogen { get; set; }
      
        public bool Eat(IFood food)
        {
            IMeat meat = food as IMeat;
            if (meat != null)
            {
                Protein = meat.Protein;
                Carbohydrate = meat.Carbohydrate;
                Nitrogen = meat.Nitrogen;
                return true;
            }
            return false;
        }
    }
