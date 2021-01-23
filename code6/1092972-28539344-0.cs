    if (!order.Approved)
    {
        Bus.Defer(TimeSpan.FromHours(1), message);
        //This will defer message handling by an hour
    }
    else
    {
        SendMail(order);
    }
