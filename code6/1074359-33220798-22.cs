    var genderSelectItems = Enum.GetValues(typeof(Gender))
        .Cast<string>()
        .Select(genderString => new SelectListItem 
        {
            Text = genderString,
            Value = genderString,
        }).AsEnumerable();
