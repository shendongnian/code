    foreach( var order in orders ){
      var splitString = order.Split(';');
      orderList.Add( new Order{
        OrderNumber = splitString[0],
        OrderId = splitString[1],
        OrderSomeThingElse = splitString[2]
      });
    }
