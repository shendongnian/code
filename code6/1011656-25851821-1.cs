    foreach (var item in myBookingList)
    {
        MyBookingsViewModel model = new MyBookingsViewModel();
        model.Carts.RecordId = item.RecordId;
        model.Carts.CartId = item.CartId;
        model.Carts.Booking.Item.ItemName = item.Booking.Item.ItemName;
        model.Carts.Booking.UserFullName = item.Booking.UserFullName;
        model.Carts.Booking.RequestDate = item.Booking.RequestDate;
        model.Carts.StatusCode.StatusCodeName = item.StatusCode.StatusCodeName;
        result.Add(model);
    }
