        public IEnumerable<Brand_Details> Get()
        {
            using (ProductEntities obj = new ProductEntities())
            {
                this.Configuration.ProxyCreationEnabled = false;
                return obj.Brand_Details.ToList();
            }
        }
