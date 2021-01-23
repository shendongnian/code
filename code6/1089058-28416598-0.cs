	public List<PriceModel> GetPriceModelList(
        List<PriceModel> priceModelList, 
        IEnumerable<Product> products) 
	{
	    priceModelList.AddRange(from result in products
	                            from item in result.Product.Price
	                            select new PriceModel 
	                            {
	                                Price = item.price
	                            });
	    return priceModelList;
	}
