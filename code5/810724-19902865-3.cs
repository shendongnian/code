    Items = Mapper.Map<List<PurchaseOrder>, List<PurchaseOrderViewModel>>(
                    purchaseOrderRepository
                       .GetMany(x => SqlFunctions
                                      .StringConvert((double?) x.PurchaseOrderID)
                                      .Contains(text))
                                      .ToList());
