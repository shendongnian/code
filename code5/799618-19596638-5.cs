    bool isBusiness = !string.IsNullOrEmpty(data["businessName");
    if(isBusiness) {
       this.MapBusinessRow(data);
    }
    else {
       this.MapCustomerRow(data)
    }
