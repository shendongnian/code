    public IEnumerable<City> GetDataForSecondDropDownList(int ID)
    {            
        using (var context = new ABCEntities())
        {
            var _city = (from u in context.Cities
                        where u.StateID == ID
                        select new City
                        {
                            CityID = u.CityID,
                            City= u.City
                        }).Distinct();
            return _city;
        }
    }
