    using(DMS_GenericDataContext db = new DMS_GenericDataContext())
    {
    
        Document_Master doc1 = db.Document_Masters
                                 .Where(c => c.Document_Id_Prefix == "PRD_TST_TST1_T2_" &&                  c.Document_Id == "2")
                                 .SingleOrDefault();
    
        // If the record exists, then make the corresponding update. 
        if(doc1!=null)
        {
           doc1.User_IDD = "anuragnigam";
           db.SaveChanges();
        }
    }
