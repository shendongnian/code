    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
    
        public bool test
        {
            get { return id > 3;}
        }
    
        public static Expression<Func<Product, dynamic>> TestExpression = 
    					p => new
                           {
                               id = p.id,
                               name = p.name,
                               mytest = p.id > 3
                           };
    }
