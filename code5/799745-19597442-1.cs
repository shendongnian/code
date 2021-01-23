    public static class StaticFunctions
    {
        public static IQueryable<ProductCollection<T>> ListedProducts<T>(this IQueryable<ProductCollection<T>> collection)
        where T : Product
        {
            return collection.Where(x => x.Listed == true);
        }
    }
    public class ProductCollection<T>
        where T:Product
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public virtual ICollection<T> Products { get; set; }
        public bool Listed { get; set; }
    }
    public class BikeCollection : ProductCollection<BikeProduct>
    {
        //Bike specific collection
    }
    public class BikeProduct:Product
    {
        //Can be anything
    }
    public class Product
    {
        //Can be anything
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
             InitializeComponent();
             IQueryable<ProductCollection<BikeProduct>> titi = new EnumerableQuery<ProductCollection<BikeProduct>>(new List<ProductCollection<BikeProduct>>());
            
            titi.ListedProducts();
            var toto = 1;
        }
    }
