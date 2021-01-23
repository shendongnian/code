    lstCust.AddRange((from xx in db.vw_AllCustomization
                                      where xx.CatID == CatID && xx.ProductID == PID
    								  select xx)
    						.TolList()	// Moves to LINQ To Object here
    						.Select(xx => new itmCustomization()
                                      {
                                          itmName = xx.Description,
                                          catId = (int)xx.CatID,
                                          proId = (int)xx.ProductID,
                                          custType = (customizationType)Enum.Parse(typeof(customizationType), xx.CustType)
                                      }).ToList<itmCustomization>());
