    //join currentCart...
	var p = currentCart.Rows.Join(
			productsPurchasePrices,              //... with productsPurchasePrices
			row => row.ProductCode,              //first collection key
			purchasePrice => purchasePrice.Key,  //second collection key
			(row, purchasePrice) => new
			{
				productCode = row.ProductCode,
				productMargin = purchasePrice.ProductMargin
			});
