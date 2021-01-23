        string duplicateField;
        
        bool validationResult = db.Product.Any(x => {
                if(x.Code == entity.Code){
                duplicateField = "Code";
                    return true;
                }
        // Other field checks here
         
    }
    
    if(validationResult){
    // Error in field <duplicateField>
    }
