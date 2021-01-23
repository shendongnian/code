    public void Process(string strCustomerName, decimal decBalance)
    {
        _cusotmerRepository.Add(strCustomerName);
        var objBalanceService = new BalanceService();    <------------
        objBalanceService.AddBalance(decBalance);
    }
