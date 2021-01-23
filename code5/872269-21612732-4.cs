    GetListResponse newone = new GetListResponse ();
    newone.marker = "";                                    
    newone.count = 1;
    for (int x = 0; reader.Read(); x++)
    {
        newone.orderDetails[x] = new Details();
        newone.orderDetails[x].order.orderId = Convert.ToInt32(reader[4]);
        newone.orderDetails[x].order.orderPlacedTime = Convert.ToUInt64(reader[0]);
        newone.orderDetails[x].order.orderValue = Convert.ToInt32(reader[3]) * Convert.ToDecimal(reader[5]);                
        newone.orderDetails[x].order.ItemDetails = new List<GetListResponseDetailsItemDetails>(1);
        newone.orderDetails[x].order.ItemDetails[0].Price = Convert.ToDecimal(reader[5]);
        newone.orderDetails[x].order.ItemDetails[0].filledQuantity = Convert.ToInt32(reader[3]);
        newone.orderDetails[x].order.ItemDetails[0].ItemNumber = 0;
        newone.orderDetails[x].order.ItemDetails[0].orderedQuantity = Convert.ToInt32(reader[3]);
    }
