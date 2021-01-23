    foreach(int id in viewModel.ContractDeliveryList.SelectMany(a => a.DeliveryList)
                                                    .Select(b => b.Employee.Id)
                                                    .Distinct() )
    {
        ....
    }
