    public class ProductJSON
    {
    	public string id { get; set; }
    	public string name { get; set; }
    	public List<Tree> tree { get; set; }
    }
    public class Tree
    {
    	public string id { get; set; }
    	public string name { get; set; }
    }
    
    public class Product
    {
    	public string id { get; set; }
    	public string name { get; set; }
    	public List<Product> tree { get; set; }
    	public Product(string _id, string _name)
    	{
    		id = _id;
    		name = _name;
    		tree = new List<Product>();
    	}   
    }
...
    List<ProductJSON> Products = JsonConvert.DeserializeObject<List<ProductJSON>>(json);
    
    List<Product> ProductList = new List<Product>();
    for(int i = 0; i < Products.Count; i++)
    {
    	ProductList.Add(new Product(Products[i].id, Products[i].name));
    	foreach (Tree t in Products[i].tree)
    	{
    		ProductList[i].tree.Add(new Product(t.id, t.name));
    	}
    }
    data.CanExpandGetter = delegate(object x) { return true; };
    data.ChildrenGetter = delegate(object x) { return ((Product)x).tree; };
    cID.AspectGetter = delegate(object x) { return String.Format("{0,3:D3}", ((Product)x).id); };
    cName.AspectGetter = delegate(object x) { return ((Product)x).name; };
    data.Roots = ProductList;
