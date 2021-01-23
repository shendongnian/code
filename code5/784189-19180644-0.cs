                for(int i=0; i<orders.Count; i++)
                {
                    if (orders[i].PaymentStatus == PaymentStatus.Paid)
                    {
                        if (orders[i].ShippingStatus == ShippingStatus.ShippingNotRequired || order.ShippingStatus == ShippingStatus.Delivered)
                        {       
                           var tempOrder = _orderService.GetOrderById(orders[i].Id);                 
                            SetOrderStatus(tempOrder , OrderStatus.Complete, true);
                        }
                    }
                }
