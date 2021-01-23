    var allCustomerNodeDatas = xdoc.Root.Descendants("Customer")
							   .Select(x => new
								{
									 NodeName = x.Name,
									 AttributesDatas = x.Attributes().Select(attr => new
									 {
										 AttributeName = attr.Name,
										 AttributeValue = attr.Value
									 }).ToList()
								}).ToList();
		
