    public List<baseClassProduct> GetAllProduct()
    { 
    	List<baseClassProduct> lst = new List<baseClassProduct>();
    	lst = (from c in dc.ProductDetailsTbls
    			 join d in dc.ProductTypeTbls
    			 on c.PTypeID equals d.PTypeID
    			 select new baseClassProduct { sPName=c.PName, sPDescription=c.PDescription, sPPrice=c.PPrice, sPType=d.PType }).ToList();
       return lst;
    }
