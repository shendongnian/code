    public async Task<wsRef_SalesOrder.Sales_Order> GetAsyncRecords(string _strNo)
    {
        wsRef_SalesOrder.Sales_Order_PortClient _ws = GetService();
        wsRef_SalesOrder.Sales_Order _rec = null;
        _ws.ReadCompleted += delegate(object sender, wsRef_SalesOrder.ReadCompletedEventArgs e)
        {
            _rec = e.Result;
        };
        await _ws.ReadAsync(_strNo);
        if (_ws.State == System.ServiceModel.CommunicationState.Opened)
            _ws.Close();
        return _rec;
    }  
