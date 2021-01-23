    public Customer Get(string id)
    {
        NorthwindEntities db=new NorthwindEntities();
        var data = from item in db.Customers
                    where item.CustomerID == id
                    select item;
        Customer obj = data.SingleOrDefault();
        if (obj == null)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("No customer with ID = {0}", id)),
                ReasonPhrase = "Localzed message CustomerID Not Found in Database!"
            };
            throw new HttpResponseException(msg);
        }
        else
        {
            return obj;
        }
    }
