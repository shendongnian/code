    var pred = OrderFields.Value > 50000 & OrderDetailFields.Quantity > 1;
    var rpb = new RelationPredicateBucket();
    rpb.PredicateExpression.Add(pred);
    rpb.Relations.Add(CustomerEntity.Relations.OrderEntityUsingCustomerId);//perform customer and order join
    rpb.Relations.Add(OrderEntity.Relations.OrderDetailEntityUsingOrderId);//perform order and order detail join
