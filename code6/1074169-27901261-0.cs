    hi: you can define a static property to share to all place in your project:
    
   
     public static class Global
        {
        
        public static SelectList Vendor()
        {
          return (new SelectList(db.Usp_VendorList(), "VendorId", "VendorName"));
        }
        
        }
    
    and use in your views like this:
