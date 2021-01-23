    var payment =
        new
        {
            Gross = gross,
            Tax = taxAmount,
            Commission = commAmount,
            TotalPayedByCustomer = new Func<decimal>(
                () =>
                    {
                        var totalPayed = 0m;
                        foreach (var custPay in customerPayments)
                        {
                            if (custPay.Payed)
                            {
                                totalPayed += custPay.Amount;
                            }
                        }
    
                        return totalPayed;
                    }),
        };
