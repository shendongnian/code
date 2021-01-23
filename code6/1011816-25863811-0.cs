    var list = Enum.GetValues(typeof(DomainObjects.Client.GenderList))
                    .Cast<DomainObjects.Client.GenderList>()
                    .Select(v => new SelectListItem { Text = v.ToString(), Value = ((int)v).ToString(), Selected = gName.ToString() == ((int)v).ToString() });
    
                return list.ToList();
  
