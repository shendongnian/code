    public void Update(Recipe recipe)
    {            
        if (recipe == null) 
            return;                
        var originalRecipe = DataContext.Recipes.SingleOrDefault(i => i.Id == recipe.Id);
        if (originalRecipe == null) 
            return; 
        originalRecipe.Name= recipe.Name;
        originalRecipe.WeightCooked = recipe.WeightCooked;
        originalRecipe.IsAlsoIngredient = recipe.IsAlsoIngredient;
        foreach(var item in recipe.Items)
        {
            var originalItem = DataContext.RecipeItems.SingleOrDefault(i=>i.Id == item.Id);
			if(originalItem == null)
				return;
            originalItem.Quantity = item.Quantity;
			...
        }
        DataContext.SaveChanges();
    }
