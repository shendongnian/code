    private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    private string ingredient;
        public string Ingredient
        {
            get { return ingredient; }
            set { ingredient = value; }
        }
    public Recipe(string name, string ingredient){
    this.name = name; 
    this.ingredient = ingredient;
    }
