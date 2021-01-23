    var rand = new Random();
    propertyIDSearch = (from p in db.Property.Include(op => op.OfficeProperties).Include(o => o.Office)                                                                            
                    where p.Office.status == 1 && p.OfficeProperties.where(op => op.active_listing == true).Any()
                    orderby Guid.NewGuid()    
                    select new SearchListing
                    {
                        property_id = p.property_id,
                        OfficeProperty = p.OfficeProperties[rand.Next(p.OfficeProperties.Count())] // you can get the description inside this properties...
                        property_name = p.prop_name,
                        property_street = p.street,
                        property_city = p.city,
                        property_state = p.state,
                        property_zip = p.zip,
                        numBedrooms = p.bed_rooms,
                        numBathrooms = p.baths,
                        numGarages = p.garage
                    })
                   .Take(1)
                   .ToList<SearchListing>();
