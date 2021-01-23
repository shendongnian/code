    [HttpPost]
    public async Task IPN(PaypalIPNBindingModel model)
    {
        var body = await Request.Content.ReadAsStringAsync(); // body will be "".
    }
