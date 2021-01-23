    public class Product : IProduct
    {
       private List<Ingredient> _ingredients;
       public IEnumerable<Ingredient> Ingredients { get { return _ingredients; } }
    }
 
