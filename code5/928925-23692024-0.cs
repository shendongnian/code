    Public IHttpActionResult GetCustomData()
    {
        var query = (from o in Orders
                select CustomerName = o.CustomerName,
                LowerCount = o.OrderDetails.Where(f => f.Pieces >= 0 && f.Pieces <= 100).Count(),
                MidCount = o.OrderDetails.Where(f => f.Pieces >= 101 && f.Pieces <= 200).Count(),
                HighCount = o.OrderDetails.Where(f => f.Pieces >= 201).Count()
                );
    
        return Ok(JsonConvert.SerializeObject(query));
    }
