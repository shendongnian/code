    ViewBag.CustomerID= new SelectList((from s in db.customer.ToList()
                                   select new
                                      {
                                        CustomerID= s.CustomerID,
                                        FullName = s.LastName+ " " + s.FirstMidName
                                      }),
           "CustomerID",
           "FullName",
           null);
