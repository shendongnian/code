     order.OrderStatusId = model.OrderStatusId;
                     var os = order.OrderStatus;
                     //order notes, notifications
                     order.OrderNotes.Add(new OrderNote()
                     {
                         Note = string.Format("Order status has been changed to {0}", os.ToString()),
                         DisplayToCustomer = false,
                         CreatedOnUtc = DateTime.UtcNow
                     });
