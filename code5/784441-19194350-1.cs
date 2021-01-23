    public IEnumerable<SelectListItem> AddHousingType()
    {
        var query = from ht in context.tHousingType
                    orderby ht.housingType
                    select new
                    {
                        ht.housingTypeID,
                        ht.housingType
                    };
        return query.AsEnumerable()
            .Select(s => new SelectListItem
            {
                Value = s.housingTypeID.ToString(),
                Text = s.housingType
            });
    }
    public IEnumerable<SelectListItem> EditHousingType(int id)
    {
        var housingType = (from h in context.tHousehold
                          where h.householdID == id
                          select new
                              {
                                  h.tHousingStatus.FirstOrDefault().housingTypeID
                              }
                          );  
        var query = from ht in context.tHousingType
                    orderby ht.housingType
                    select new
                    {
                        ht.housingTypeID,
                        ht.housingType
                    };
        return query.AsEnumerable()
            .Select(s => new SelectListItem
               {
                   Value = s.housingTypeID.ToString(),
                   Text = s.housingType,
                   Selected = (housingType.FirstOrDefault().housingTypeID == s.housingTypeID ? true : false)
               });
    }
