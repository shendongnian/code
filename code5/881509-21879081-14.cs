    var orderDetailsViewModel = new OrderDetailsViewModel();
    foreach(var orderdetail in orderDetails)
    {
     orderDetailsViewModel.Add(new OrderDetailsViewModel { OrderId = orderDetail.OrderId, ProductId = orderDetail.ProductId, UnitPrice = orderDetail.UnitPrice, Quanity = orderDetail.quantity, Discount = orderDetail.Discount });
    }
