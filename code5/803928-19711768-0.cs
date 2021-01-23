    public class ProductBO
    {
        Product GetProduct(int ID)
        {
            // make service calls against the ID and populate DTOs from services
            WCF1.Product p1 = new WCF1.Product();
            WCF2.Product p2 = new WCF2.Product();
            WCF3.Product p3 = new WCF3.Product();
            WCF4.Product p4 = new WCF4.Product();
            p1 = WCF1.GetProduct(ID);
            p2 = WCF2.GetProduct(ID);
            p3 = WCF3.GetProduct(ID);
            p4 = WCF4.GetProduct(ID);
            // then map each to your domain Product object
            Product p = new Product();
            p.Name = p1.Name;
            p.ID = ID;
            p.Color = p2.Color;
            p.Brand = p1.Brand;
            p.Photo = p2.Photo;
            p.Weight = p4.Weight;
            return p;
        }
    }
