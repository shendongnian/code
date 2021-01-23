    public class QueryArgs
    {
       public int Id get; set;
       //rest of your fields go here
    }
    public async Task<List<Customer>> GetcustomerByName(QueryArgs param)
