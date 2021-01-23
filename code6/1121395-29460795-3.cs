        // I have omitted the (proper) instantiation of Rolls and ChosenIngredients for brevity here
        public RollCollection Rolls { get; set; }
        public List<Ingredient> ChosenIngredients { get; set; } 
        public void Update()
        {
            Rolls = Rolls.WhichContainIngredients(ChosenIngredients);
        }
