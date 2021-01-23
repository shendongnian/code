    public class FoodItem
    {
        private int numberServed;
        public FoodItem(String fname, String fdescription, int nserved, double fcost)
        {
            FoodName = fname;
            FoodDescription = fdescription;
            NumberPeople = nserved;
            FoodCost = fcost;
        }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public int NumberPeople() { get; set; }
        public double FoodCost { get; set; }
   
        public int NumberPeople
        {
            get { return numberServed; }
            set { numberServed = value <= 4 ? value : 0; }
        }
    }
