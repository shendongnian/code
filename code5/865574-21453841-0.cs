	[Route("/Recipes", "POST")]
	public class CreateRecipeRequest : IReturn<Recipe>
	{
		public string Name { get; set; }
		public string[] StepName { get; set; }
		public string[] StepDescription { get; set; }
		public int[] StepDuration { get; set; }
		public string[] IngredientName { get; set; }
		public string[] IngredientQuantityName { get; set; }
		public decimal[] IngredientQuantityValue { get; set; }
	}
