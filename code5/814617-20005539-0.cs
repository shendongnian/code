    public class CustomerController : ApiController
    {
        public Customers Get(string id)
        {
            NorthwindEntities db=new NorthwindEntities();
            var data = from item in db.Customers
                        where item.CustomerID == id
                        select item;
            Customer obj = data.SingleOrDefault();
            if (obj == null)
            {
                throw new Exception("CustomerID Not Found in Database!");
            }
            else
            {
                return obj;
            }
        }
        ...
    }
