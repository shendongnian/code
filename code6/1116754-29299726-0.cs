    var currencyCodes = _service.GetCurrencyCodes().ToList();
    var test = balanceTrans.AsEnumerable();
        var obj = test.AsEnumerable().Select(item => new SearchCardTransactionResult
        {
            PanId = item.PanId,
            CardNumber = item.CardNumberFormatted,
            Balance = item.FinancialBalance,
            BillingAmount = Math.Abs(item.BillingAmount).Format(),
            BillingCurrency = currencyCodes.First(c=>c.NumericCode.Equals(item.BillingCurrency)).AlphabeticCode
        });
