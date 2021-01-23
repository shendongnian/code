    namespace BusinessLayer
    {
        public static class CustomerMgr
        {
            private static CustomerInfoDocument _document = new CustomerInfoDocument();
    
            public static Store AddStore(string storeName)
            {
                if(string.IsNullOrWhiteSpace(storeName))
                    return null;
                Store store = new Store();
                store.Name = storeName;
                _document.StoreToCustomerList.Add(store, null);
                return store;
            }
        }
    }
