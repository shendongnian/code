    public class RecipeBook
    {
        public List<Recipe> Recipes { get; set; }
        public RecipeBook()
        {
            Recipes = new List<Recipe>();
        }
    }
    public class Recipe
    {
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public string Instructions { get; set; }
    }
    public void SomeFunction()
    {
        RecipeBook recipeBook = new RecipeBook();
        var myRecipe = new Recipe()
        {
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            Instructions = "This is how you make a cake."
        };
        recipeBook.Recipes.Add(myRecipe);
        var doc = new XDocument();
        using (var writer = doc.CreateWriter())
        {
            var serializer = new XmlSerializer(typeof(RecipeBook));
            serializer.Serialize(writer, recipeBook);
        }
        doc.Save(recipesFileFullPath);
    }
