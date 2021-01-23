	var ordersView = 
		dataContext.OrdersView
		.Where(m => m.RecordCreated >= fromDate && m.RecordCreated <= toDate && m.DepartmentID == _depID)
		.ToList(); 
	
	var ClientAggOrders = ordersView.GroupBy(m => m.Name).Select(gr => new
	{
		Name = gr.Key,
		Count = gr.Where(s => s.ID != null).Count(),
		id = gr.Select(s => s.ID),
		S1 = gr.Sum(s => s.Tare < s.Gross ? s.Tare : s.Gross),
		S2 = gr.Sum(s => s.Tare < s.Gross ? s.Gross : s.Tare),
		NetWeight = gr.Sum(s => s.NetWeight),
		Price = gr.Sum(s => s.NetPrice)
	}).ToList();
