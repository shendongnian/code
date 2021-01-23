    List<OrderItem> orderItems = new List<OrderItem>();
        foreach (var oi in fullOrder.Order)
        {
            //detach oi
             //attach oi
            var color = _colorRepo.Find(oi.ColorId);
            var item = new OrderItem
            {
                Quantity = oi.Quantity,
                Color = color
            };
            orderItems.Add(item);
        }
