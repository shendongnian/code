    var counts =(
        from product in db.Products
        group product by 1 into p
        select new
        {
            Name = p.Count(x => x.Name == name),
            Code = p.Count(x => x.Code == code),
            OtherField = p.Count(x => x.OtherField == otherFields)
        }
    ).FirstOrDefault();
    if (counts.Name > 0)
        error.Add("Duplicate name");
    if (counts.Code > 0)
        error.Add("Duplicate code");
