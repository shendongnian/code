    public interface IProduct<TEnumerable> 
        where TEnumerable : IEnumerable<Ingredient>
    {
        TEnumerable Ingredients { get; set; }
    }
    
    public class Product : IProduct<List<Ingredient>>
    {
        public List<Ingredient> Ingredients { get; set; }
    }
