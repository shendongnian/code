    // Get the entity that contains the max value, using Ordering
    var myMaxIfAny = currContext.OrderDressings
    	.Where(yy => yy.OrderID == this.OrderID && yy.OrderItemID == this.orderItemID && yy.ProductID == this.ProductID)
    	.OrderByDescending(z => z.SrNo)
    	.FirstOrDefault();
    
    if (myMaxIfAny != null)
    {
    	// Then you got a value, retrieve the Max using myMaxIfAny.SrNo
    	// ...
    }
    else
    {
    	// ...
    }
