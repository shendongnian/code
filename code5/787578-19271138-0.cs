    list = list.OrderBy(kn => {
        var digits = kn.Name.Split().Last();
        int num = int.MaxValue;
        if (digits.All(Char.IsDigit))
        { 
            num = int.Parse(new string(digits.ToArray()));
        }
        return num;
    }).ToList();
