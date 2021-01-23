    var currentTime = DateTime.Now;
    var today = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
    var yesterDay = today.Subtract(new TimeSpan(1, 0, 0, 0));
      
    //suppose, that we gather all data for yesterday  
    var query1 = from opv in _opvRepository.Table
                     join o in _orderRepository.Table on opv.OrderId equals o.Id
                     join pv in _productVariantRepository.Table on opv.ProductVariantId equals pv.Id
                     join p in _productRepository.Table on pv.ProductId equals p.Id
                     where yesterDay <= o.OrderDate && today >= o.OrderDate
                     select opv;
      
    var query2 = groupBy == 1 ?
        //group by product variants
           from opv in query1
           group opv by opv.ProductVariantId into g
           select new
           {
               EntityId = g.Key,
               TotalAmount = g.Sum(x => x.PriceExclTax),
               TotalQuantity = g.Sum(x => x.Quantity),
           }
           :
        //group by products
           from opv in query1
           group opv by opv.ProductVariant.ProductId into g
           select new
           {
               EntityId = g.Key,
               TotalAmount = g.Sum(x => x.PriceExclTax),
               TotalQuantity = g.Sum(x => x.Quantity),
           }
           ;
      
