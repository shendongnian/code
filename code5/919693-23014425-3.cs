    public string AddessLine {
       get 
       { 
          return StringExtensions.JoinNonEmpty(", ", FullAddress.Address, 
                                               FullAddress.Address2,
                                               FullAddress.Town); 
       }
    }
