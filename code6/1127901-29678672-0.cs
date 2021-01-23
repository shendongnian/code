    [Flags]
    public enum Context
    {
        NET = 1,
        LOCAL = 2,
        LICENSES = 4
    }
    public class Product
    {
        public Context Context;
        public string Name;
    }
    Product[] items = new[]
    {
        new Product { Name = "Adobe", Context = Context.NET },
        new Product { Name = "Adobe", Context = Context.LICENSES },
        new Product { Name = "Adobe", Context = Context.LOCAL },
        new Product { Name = "Adobe2", Context = Context.LOCAL },
        new Product { Name = "Adobe2", Context = Context.NET }
    };
