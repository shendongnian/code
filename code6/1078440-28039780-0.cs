    var query = Context.Orders
            .Where(o => o.ProposedOrder == ProposedOrders
                && o.Inactive == false
                && o.OnHold == false
                && o.Archive == false
                && (!o.ManufactureSiteFlag.HasValue || (o.ManufactureSiteFlag & currentSite) > 0);
    if (FilterOnDispatch.FilterOnDispatch.Equals("YES"))
        query = query.Where(o=>o.Deliveries.Count(d => d.Dispatched == true) > 0);
    else if (FilterOnDispatch.FilterOnDispatch.Equals("NO"))
        query = query.Where(o=>o.Deliveries.Count(d => d.Dispatched == false) > 0);
    
    dgOrders.DataSource = query;
