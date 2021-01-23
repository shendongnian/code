    private Func<Subscription, bool> GenerateQuery(FilterSubscription filterSubscription)
    {
      if (filterSubscription.FilterByOrder)
        return s => s.Account.Orders.Any();
      if (filterSubscription.FilterByInvoice)
        return s => s.Account.Orders.Any(o => o.Invoices.Any());
    }
