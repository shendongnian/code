    public string ReturnFields(TObject objectSaved, TObject objectChanged)
    {
    
        var sb = new StringBuilder();
    
       if(!objectSaved.Name.Equals(objectChanged.Name)
       {
         
         sb.Append("Name was changed from " + objectSaved.Name  +" to: " + objectChanged.Name)
     
       }
    
       if(!objectSaved.OrderDate.Equals(objectChanged.OrderDate)
       {
        
       sb.Append("The date whas changed from " + objectSaved.OrderDate+" to: " + objectChanged.OrderDate)
     
       }
    
        return sb.ToString();
    }
