    bool isBusiness = string.IsNullOrEmpty(data["businessName") ? false : true;
    if(isBusiness) {
       this.MapBusinessRow(data);
    }
    else {
       this.MapCustomerRow(data)
    }
