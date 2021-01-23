    public class Recipe
	{
		public string Name { get; set; }
		public Ingredient[] Ingredients { get; set; }
		public Step[] Steps { get; set; }
	}
	public class Ingredient
	{
		public string Name { get; set; }
		public string QuantityName { get; set; }
		public decimal Quantity { get; set; }
	}
	public class Step
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Duration { get; set; }
	}
	public class RecipeService : Service
	{
		public Recipe Post(CreateRecipeRequest request)
		{
			// Convert the flat CreateRecipeRequest object to a structured Recipe object
			// Steps
			int numberOfSteps = request.StepName.Length;
			// Ingredients
			int numberOfIngredients = request.IngredientName.Length;
			// Check there is a description and duration for all steps
			if(request.StepDescription == null || request.StepDescription.Length != numberOfSteps || request.StepDuration == null || request.StepDuration.Length != numberOfSteps)
				throw new Exception("There must be a duration and description for all steps");
			// Create the Recipe object
			var recipe = new Recipe { Name = request.Name, Steps = new Step[numberOfSteps], Ingredients = new Ingredient[numberOfIngredients] };
			for(int s = 0; s < numberOfSteps; s++)
				recipe.Steps[s] = new Step { Name = request.StepName[s], Description = request.StepDescription[s], Duration = request.StepDuration[s] };
			// Check there is a quantity type and quantity value for all ingredients
			if(request.IngredientQuantityName == null || request.IngredientQuantityName.Length != numberOfIngredients || request.IngredientQuantityValue == null || request.IngredientQuantityValue.Length != numberOfIngredients)
				throw new Exception("The quantity must be provided for each ingredient");
			for(int i = 0; i < numberOfIngredients; i++)
				recipe.Ingredients[i] = new Ingredient { Name = request.IngredientName[i], QuantityName = request.IngredientQuantityName[i], Quantity = request.IngredientQuantityValue[i] };
				
			/*
			 * Recipe can now be accessed through a logical collection:
			 * 
			 * recipe.Name
			 * recipe.Steps[0].Name
			 * recipe.Ingredients[1].Quantity
			 * 
			 */
			return recipe;
		}
	}
