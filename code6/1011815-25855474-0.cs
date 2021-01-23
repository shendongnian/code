    var list = Enum.GetValues(typeof(DomainObjects.Client.GenderList))
                .Cast<DomainObjects.Client.GenderList>()
                .Select(v => new SelectListItem {
        Text = v.ToString(),
        Value = ((int)v).ToString()});
    var maleGenderItem = list.Single(x => x.Text == "Male");
    maleGenderItem.Selected = true;
