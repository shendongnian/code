    var projectedOrders = (from order in orders
                              select new
                              {
                                  orderId = order.Id,
                                  orderName = order.FriendlyName,
                                  OrderDate = order.OrderDate,
                                  UserId= order.UserId
                              })
                           .ToArray()
                           .Select(o =>
                               new{
                                  o.orderId,
                                  o.orderName,
                                  o.OrderDate,
                                  CustomerName = helper.GetUserNameByUserId(o.UserId)
                              
                               });
