    public class RecipeVM
    {
        public RecipeVM(Recipe r)
        {
            recipe = r;
        }
        Recipe recipe;
        public int Id 
        { 
            get
            {
                return recipe.Id;
            }
            set
            {
                PropertyChanged("Id");
                recipe.id = value;
            }
        }
        public string Title
        {
            get
            {
                return recipe.Title;
            }
            set
            {
                PropertyChanged("Title");
                recipe.Title = value;
            }
        }
        ObservableCollection<RecipeIngredient> ingredients;
        public ObservableCollection<RecipeIngredient> Ingredients 
        {
            get
            {
                if (ingredients == null)
                    ingredients = new ObservableCollection<RecipeIngredient>(recipe.Ingredients);
                return ingredients;
            }
            set
            {
                PropertyChanged("Ingredients");
                ingredients = value;
            }
        }
    }
