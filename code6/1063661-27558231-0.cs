         public void Test()
         {
             List<Recipes> recipes = new List<Recipes>();
             List<Ingredient> UsedIngredients = new List<Ingredient>();
             UsedIngredients = (from a in recipes where UsedIngredients.Contains(a.ingredient) select a.ingredient).ToList();
         }
