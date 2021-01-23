    foreach(var v in vendor)
                {
                    var s = new ResturantCoordinatesModel();
                    var values = new NopDestek.StoreMapFinder.Domain.Resturant_Coordinates();
                    
                       values = (from t in _resturantCoordinates.Table
                                      where t.VendorId == v.Id
                                      select t).FirstOrDefault();
                    
                    s.Id = v.Id;
                    s.Name = v.Name;
                    s.Latitude = values == null? 0 : values.Latitude;
                    s.Longitude = values == null ? 0 : values.Longitude;
    
                    model.Add(s);
    
                }
