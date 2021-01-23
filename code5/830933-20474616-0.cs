    costPages = table.AsEnumerable().GroupBy(dr=> new 
    			{
    				CostPageNumber  = dr[0].ToString(),
    				Description = dr[1].ToString(),
    				OrderType = Convert.ToChar(dr[2].ToString()),
    				VendorName = dr[3].ToString()
    			})
    			.Select(x => new CostPageDTO(){
    				CostPageNumber = x.Key.CostPageNumber,
    				Description = x.Key.Description,
    				OrderType = x.Key.OrderType,
    				VendorName = x.Key.VendorName,
    				Items = x.Select(dr=> new ItemDTO{
    					//ItemDTO mapping goes here
    				}).ToList()
    			}).ToList();
