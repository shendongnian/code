    public static List<v_POVendor> GetPOVendorList(string connectionStringName)
    {
    
       using (WMSEntities db = new WMSEntities(connectionStringName))
       {               
           vendorList = db.v_POVendor.ToList();
       }
    }
