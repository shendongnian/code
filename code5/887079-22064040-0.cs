    public IQueryable GetAllvendor()
            {
                CommonDataContext VendorDC = new CommonDataContext(Settings.ConnectionString);
                {
                    VendorDC.DeferredLoadingEnabled = false;
    
                    var List = (from V in VendorDC.tblaccounts
                                join C in VendorDC.vendorCategories on V.CatID equals C.Vendor_CatID
                                where V.Sys_AC_type == 7
                                select new
                                {
                                    V.ID,
                                    V.ACCOUNT,
                                    V.field2,
                                    V.contactDetails,
                                    V.Remarks,
                                    V.field3,
                                    V.field1,
                                    V.email,
                                    V.fax,
                                    C.vendor_CategoryName
                                });
    
                    return List;
                }
    
            }
