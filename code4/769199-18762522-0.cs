     void BindGridTypeSafe()
        {
            NorthwindDataContext northwind = new NorthwindDataContext();
    
            var query = from p in northwind.Products
                        where p.CategoryID == 3 && p.UnitPrice > 3
                        orderby p.SupplierID
                        select p;
    
            GridView1.DataSource = query;
            GridView1.DataBind();
        }
    
        void BindGridDynamic()
        {
            NorthwindDataContext northwind = new NorthwindDataContext();
    
            var query = northwind.Products
                                 .Where("CategoryID = 3 AND UnitPrice > 3")
                                 .OrderBy("SupplierID");
    
            GridView1.DataSource = query;
            GridView1.DataBind();
        }
