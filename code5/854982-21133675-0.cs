    var allOrders2 = customerList.SelectMany(cust => cust.Orders, 
                                             (cust, ord) => new
                                             {
                                                cust,
                                                ord
                                             })
                                  .Join(productList, 
                                        x => x.ord.ProductID, 
                                        prod => prod.ProductID, 
                                        (x, prod) => new
                                        {
                                            Name = x.cust.Name,
                                            ProductID = x.ord.ProductID,
                                            OrderAmount = (double)x.ord.Quantity * prod.Price
                                        });
    var summe2 = customerList.GroupJoin(allOrders, 
                                        cust => cust.Name, 
                                        ord => ord.Name, 
                                        (cust, custWithOrd) => new
                                        {
                                            Name = cust.Name,
                                            TotalSumme = custWithOrd.Sum(s => s.OrderAmount)
                                        });
