    priceModelList.AddRange(from result in new List<dynamic>(resultsList)
                            select new PriceModel
                            {
                                Price = result.Product.Price
                            });
