    public class Controller
    {
        private RollCollection _availableRolls = new RollCollection();
        private List<Ingredient> _availableIngredients = new List<Ingredient>();
        public RollCollection AvailableRolls
        {
            get { return _availableRolls; }
        }
        public List<Ingredient> AvailableIngredients
        {
            get { return _availableIngredients; }
        }
        public RollCollection RollsFilteredByIngredients
        {
            get { return AvailableRolls.WhichContainIngredients(ChosenIngredients); }
        }
        public List<Ingredient> ChosenIngredients { get; set; }
        public Controller()
        {
            ChosenIngredients = new List<Ingredient>();
            InitializeTestData();
        }
        private void InitializeTestData()
        {
            Ingredient ingredient1 = new Ingredient("Ingredient1");
            Ingredient ingredient2 = new Ingredient("Ingredient2");
            Ingredient ingredient3 = new Ingredient("Ingredient3");
            _availableIngredients.Add(ingredient1);
            _availableIngredients.Add(ingredient2);
            _availableIngredients.Add(ingredient3);
            Roll roll1 = new Roll("Roll1");
            roll1.AddIngredient(ingredient1);
            roll1.AddIngredient(ingredient2);
            Roll roll2 = new Roll("Roll2");
            roll2.AddIngredient(ingredient3);
            _availableRolls.AddRoll(roll1);
            _availableRolls.AddRoll(roll2);
        }
    }
