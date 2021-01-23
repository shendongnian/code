    Cloudinary cloudinary = new Cloudinary(account);
        
    List<string> IDlist = new List<string>();
    list.Add("outbox,zip");
        
    DelResParams delParams = new DelResParams();
    delParams.PublicIds = IDlist;
    delParams.Type = "multi";
        
    cloudinary.DeleteResources(delParams);
                    
