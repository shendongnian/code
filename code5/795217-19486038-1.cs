    String column = e.SortExpression;
    IQueryable<dynamic> sortedGridview = ConvertSortDirectionToSql(e.SortDirection) == "ASC" ?
												(from r in context.Ranges
                                                 where r.isDeleted == false												 
                                                 orderby typeof(Range).GetProperty(column).GetValue(r,null) ascending
												 select new
												 {
												  r.RangeId,
                                                  Description = r.Description,
                                                  CountryName = r.Country.CountryName,
                                                  RegionName = r.GeographicRegion.RegionName,
                                                  BaseName = r.Base.BaseName,
                                                  r.RangeMap.MapName,
                                                  r.RangeMap.MapPath,
                                                  r.RangeMap.LowLat,
                                                  r.RangeMap.LowLong,
                                                  r.RangeMap.HighLat,
                                                  r.RangeMap.HighLong
												 }).AsQueryable<dynamic>() :
												  (from r in context.Ranges
                                                   where r.isDeleted == false												   
                                                   orderby typeof(Range).GetProperty(column).GetValue(r, null) descending
												   select new
												   {
                                                  r.RangeId,
                                                  Description = r.Description,
                                                  CountryName = r.Country.CountryName,
                                                  RegionName = r.GeographicRegion.RegionName,
                                                  BaseName = r.Base.BaseName,
                                                  r.RangeMap.MapName,
                                                  r.RangeMap.MapPath,
                                                  r.RangeMap.LowLat,
                                                  r.RangeMap.LowLong,
                                                  r.RangeMap.HighLat,
                                                  r.RangeMap.HighLong
												   }).AsQueryable<dynamic>();
