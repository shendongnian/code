    public List<Users> GetAll()
            {
                using (ProductStoreEntities ProductStoreDB = new ProductStoreEntities())
                {
                    return ProductStoreDB.Users.ToList();
                }
            }
