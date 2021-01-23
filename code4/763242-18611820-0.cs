    var request = new GetOrdersRequestType
    {
    	//OutputSelector = new StringCollection {"OrderID","Total"},
    	CreateTimeFrom = Convert.ToDateTime(Request.Form["dateFrom"] + "T00:00:00.000Z"),
    	CreateTimeTo = Convert.ToDateTime(Request.Form["dateTo"] + "T23:59:59.999Z"),
    	OrderStatus = (OrderStatusCodeType)Enum.Parse(typeof(OrderStatusCodeType), Request.Form["statusCode"]),
    	OrderRole = TradingRoleCodeType.Seller,
    	Pagination = new PaginationType
    		{
    			EntriesPerPage = Util.RecordsPerPage(),
    			PageNumber = int.Parse(Request.Form["pageNumber"])
    		}
    };
    
    var apicall = new GetOrdersCall(context)
    	{
    		ApiRequest = request,
    		OutputSelector =
    			new string[]
    				{
    					"OrderID", "Total", "PaidTime", "eBayPaymentStatus",
    					"PaymentMethod", "Title", "PageNumber", "PaginationResult.TotalNumberOfPages"
    				}
    	};
    
    apicall.Execute();
    var orders = apicall.ApiResponse.OrderArray;
