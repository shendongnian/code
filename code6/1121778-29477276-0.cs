	var order = _db.Orders.Find(orderId);
	var stores = _db.Stores; // take all stores from DB
	var orderVm = new EditOrderVm {
	  OrderId = order.Id,
	  OrderItems = order
				   .OrderItems
				   .Select(o => new EditOrderItemVm {
					 OrderItemId = o.Id,
					 OrderId = o.OrderId,
					 ProductId = o.ProductId,
					 Stores = (from sc in o.Product.Stocks
							   from st in stores // all stores
							   select new {
								 Id = sc.Store.Id,
								 Name = sc.Store.Name
							}).ToSelectList(
								s => s.Name,
								s => s.Id, 
								s => o.Stores.Any(sto => sto.Id == s.Id) //select only existing stores
							)
				   })
	}
