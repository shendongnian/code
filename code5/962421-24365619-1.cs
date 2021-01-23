       var viewmodel = new FreemiumViewModel
       {
            Skus = Context.Instance.StockKeepingUnits.ToList(),
            Features = Context.Instance.Features.ToList()
            ...
       };
