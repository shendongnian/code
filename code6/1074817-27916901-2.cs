    var duplicates =(
        from product in db.Products
        group product by 1 into p
        select new
        {
            Name = g.Any(x => x.Name == name),
            Code = g.Any(x => x.Code == code),
            OtherField = g.Any(x => x.OtherField == otherFields)
        }
    ).FirstOrDefault();
    if (duplicates.Name)
        error.Add("Duplicate name");
