    public class OrderService : Service 
	{
		public List<CustomerMonthlyOrders> Get(GetOrderHistoryRequest request)
		{
			// Perform the query to get all orders within the range
			// (NOTE: SQL is untested, and will need tweaked to your db)
			List<Order> allOrders = Db.SqlList<Order>("SELECT * FROM Orders WHERE OrderDate >= @Start AND OrderDate < @End", new {
				Start = request.StartDate,
				End = request.EndDate
			});
			// Prepare response object
			var customerMonthlyOrders = new List<CustomerMonthlyOrders>();
			// Get the distinct customer Ids
			var customers = orders.Select(o => o.CustID).OrderBy(o => o).Distinct();
			foreach(var custId in customers)
			{
				// Create a result for the customer
				var result = new CustomerMonthlyOrders { 
					CustID = custId,
					QuantitiesOrdered = new Dictionary<string, int>()
				};
				// Get the customers relevant orders
				var orders = allOrders.Where(o => o.CustID == custId);
				foreach(var order in orders)
				{
					// Determine the month the order belongs to (i.e. the key)
					var month = order.OrderDate.ToString("MMM-yyyy");
					// Add or update the quantities
					if(result.QuantitiesOrdered.ContainsKey(month))
						result.QuantitiesOrdered[month] += order.Qty;
					else
						result.QuantitiesOrdered.Add(month, order.Qty);
				}
				// Add the customers order to the results
				customerMonthlyOrders.Add(result);
			}
			// Return the results
			return customerMonthlyOrders;
		}
	}
