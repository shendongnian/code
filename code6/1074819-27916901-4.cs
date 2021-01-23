    var duplicates =(
        from product in db.Products
        group product by 1 into p
        select new
        {
            Name = p.Any(x => x.Name == name),
            Code = p.Any(x => x.Code == code),
            OtherField = p.Any(x => x.OtherField == otherFields)
        }
    ).FirstOrDefault();
    if (duplicates.Name)
        error.Add("Duplicate name");
