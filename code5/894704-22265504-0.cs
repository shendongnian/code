    if(!String.IsNullOrWhiteSpace(oProd.SectionName)){
        oProdList = oProdList.Where(oProd => oProd.SectionName.ToUpper().Contains(ProductName.ToUpper().Trim());
    }
    
    if(!String.IsNullOrWhiteSpace(oProd.Size)){
        oProdList = oProdList.Where(oProd => oProd.Size.ToUpper().Contains(size.ToUpper().Trim());
    }
