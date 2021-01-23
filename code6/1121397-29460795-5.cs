    public class Roll
    {
        private string _name;
        private List<Ingredient> _ingredients = new List<Ingredient>();
        public string Name
        {
            // By only exposing the property through a getter, you are preventing the name
            // from being changed after the roll has been created
            get { return _name; }
        }
        public List<Ingredient> Ingredients
        {
            // Similarly here, you are forcing the consumer to use the AddIngredient method
            // where you can do any necessary checks before actually adding the ingredient
            get { return _ingredients; }
        }
        public Roll(string name)
        {
            _name = name;
        }
        public bool AddIngredient(Ingredient ingredient)
        {
            // Returning a boolean value to indicate whether the ingredient was already present,
            // gives the consumer of this class a way to present feedback to the end user
            bool alreadyHasIngredient = _ingredients.Any(i => i.Name == ingredient.Name);
            if (!alreadyHasIngredient)
            {
                _ingredients.Add(ingredient);
                return true;
            }
            return false;
        }
        public bool ContainsIngredients(IEnumerable<Ingredient> ingredients)
        {
            // We use a method group to check for all of the supplied ingredients 
            // whether or not they exist
            return ingredients.All(ContainsIngredient);
            // Could be rewritten as: ingredients.All(i => ContainsIngredient(i));
        }
        public bool ContainsIngredient(Ingredient ingredient)
        {
            // We simply check if an ingredient is present by comparing their names
            return _ingredients.Any(i => i.Name == ingredient.Name);
        }
    }
