    public class DDL {
        public static readonly Expression<Func<Product, DDL>> Map =
            o => new DDL {
                id = o.identifier,
                name = o.pbfeattext
            };
        public static readonly Func<Product, DDL> ToMap = 
            DDL.Map.Compile();
        public int id {get;set;}
        public string name {get;set;}
    }
