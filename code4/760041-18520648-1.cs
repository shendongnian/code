    public List<ProductAndCategoryID> populate()
        {
            ShippingClassHelper helper = new ShippingClassHelper();
            DataSet ds = new DataSet();
            List<ProductAndCategoryID> list = new List<ProductAndCategoryID>();
    
            ds = helper.GetProductToCategoryMatching();
    
            foreach (DataRow row in ds.Tables[0].Rows)
            {
              var pc = new ProductAndCategoryID();
              pc.ProductID = row[0];
              pc.CategoryID = row[1];
              list.Add(pc);
            }
    
            return list;
        }
