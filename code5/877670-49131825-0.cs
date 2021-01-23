     IEnumerable<Customer> model = (from c in db.Customer
                                    from b in c.BlackList.DefaultIfEmpty()
                                     where b.CusID== null
                                      select new Customer
                                       {
                                            CusId= c.OrderID
                                        }).ToList();
