        public List<CustomerObject> FetchCustomersByName(CustomerObject obj)
        {
            var customerDal = DalFactory.Create<CustomerDal>();
            //Maybe other operations
            List<CustomerObject> list = customerDal.FetchByName(obj.Name);
            //Maybe other operations over list
            return list;
        }
