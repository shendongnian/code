    var query = Product.AsQueryable();
    query = txtProd != string.Empty ?  query.Where(x => x.Id == txtProd);
    query = txtTitle != string.Empty ? query.Where(x => x.Title == txtTitle);
    query = strStatus != string.Empty ? query.Where(x => x.Status == strStatus);
   
    var results = query.ToList();
