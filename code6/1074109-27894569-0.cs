    public class Magazine : Dictionary<string, Product>
    {
       public void Add(Product p)
       {
          base[p.name] = p;
       }
    }
