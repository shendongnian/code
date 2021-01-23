    var counts =(
        from product in db.Products
        group product by 1 into p
        select new
        {
            Name = g.Count(x => x.Name == name),
            Code = g.Count(x => x.Code == code),
            OtherField = g.Count(x => x.OtherField == otherFields)
        }
    ).FirstOrDefault();
    if (counts.Name > 0)
        error.Add("Duplicate name");
    if (counts.Code > 0)
        error.Add("Duplicate code");
