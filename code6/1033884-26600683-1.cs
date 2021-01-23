    var query =
    from so in SalesOrders 
    join sol in SalesOrderLines on so.ID equals sol.SalesOrderID
    join dnl in DeliveryNoteLines on sol.RootID equals dnl.SalesOrderLineRootID
    join dn in DeliveryNotes on dnl.DeliveryNoteID equals dn.ID
    where so.IsLatestRevision == 1 && dn.IsLatestRevision == 1
    group new {
    dn.DeliveryNoteNumber
    , dnl.Quantity } by dn.DeliveryNoteNumber into g
    orderby g.Key
    select new
    {
    	DeliveryNoteNumber = g.Key,
    	ProductCount = (
    		from sol1 in SalesOrderLines 
    		join dnl1 in DeliveryNoteLines on sol1.RootID equals dnl1.SalesOrderLineRootID
    		where dnl1.DeliveryNote.DeliveryNoteNumber == g.Key
    		select sol1.ProductID
    	).Distinct().Count()
    	,	
    	QuantitySum = g.Sum( x => x.Quantity )
    };
