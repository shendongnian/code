    var addedProperties = from p in db.Property
                                      join ppic in db.PropertyPhotos on p.PropertyId equals ppic.PropertyId into pp
                                      join a in db.AreaLookUp on p.Area equals a.AreaLookUpId
                                      join cal in db.CalendarEvent on p.PropertyId equals cal.PropertyId into c
                                      where p.UserId == userId
                                      select new PropertyExcerptViewModel
                                      {
                                          PropertyId = p.PropertyId,
                                          PropertyType = p.PropertyType,
                                          PropertyCategoryDescription = pc.PropertyCategoryDescription,
                                          TransactionType = p.TransactionType,
                                          IsPropertyDisabled = p.IsPropertyDisabled,
                                          IsPropertyVerified = p.IsPropertyVerified,
                                          IsPropertyNotified = p.IsPropertyNotified,
                                          MainPicSrc = pp.Where(e => e.MainPic == true).FirstOrDefault().PhotoLocation,
                                          PhotosCount = pp.Count(),
                                          Price = p.Price,
                                          NoOfBedrooms = p.NoOfBedrooms,
                                          Area = a.AreaLookUpDescription,
                                          ShortDescription = (p.Description.Length > 300) ? p.Description.Substring(0, 300) : p.Description,
                                          LatestCalendarEvent = c.OrderByDescending(e => e.DateSaved).FirstOrDefault()
                                      };
    
                return addedProperties.ToList();
