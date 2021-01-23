    public IEnumerable<SelectListItem> CountiesList;
    CountiesList =  from c in entities.Counties
                    select new SelectListItem
                    {
                        Value = c.CountyID.ToString(),
                        Text = c.County //the county name, nvarchar/string
                    };
