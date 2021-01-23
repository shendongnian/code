    DataTable countriesTable = dt.AsEnumerable().GroupBy(x => new { CountryId = x.Field<int>("CountryId"), CityId = x.Field<int>("CityId") })
                                 .Select(x => new Countries
                                              {
                                                  CountryId = x.Key.CountryId,
                                                  CityId = x.Key.CityId,
                                                  TotalSum = x.Sum(z => z.Field<int>("TotalImages"))
                                              }).PropertiesToDataTable<Countries>();
