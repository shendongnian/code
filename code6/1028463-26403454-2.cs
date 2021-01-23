     var query2 = feedItems.GroupBy(feed => new { feed.MerchantName , feed.ProductName })
                                      .Select(items => new MerchantPerformanceAffiliate 
                                                                    {
                                                                        MerchantName = items.Key.MerchantName,
                                                                        ProductName = items.Key.ProductName,
                                                                        TotalTransactions = items.Sum(x => x.TotalTransactions)
                                                                    }).ToList();
