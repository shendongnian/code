    var paymentTypeMap = new Dictionary<string, int>
    {
        { "Credit", 1 },
        { "Open Invoice", 2 },
        ...
    }
    int paymentType;
    if (paymentTypeMap.TryGetValue(lblPayment.Text, out paymentType))
    {
        // OK 
    }
    else
    {
        // Unknown payment method
    } 
