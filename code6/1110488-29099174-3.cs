    //Load and transform by one id
    CustomerNameViewModel viewModel = session.Load<CustomerNameTransformer, CustomerNameViewModel>("customers/1");
    //Load and transform by several id's
    CustomerNameViewModel[] viewModels = session.Load<CustomerNameTransformer, CustomerNameViewModel>(new[]{ "customers/1", "customers/2"});
    //Query and transform
    List<CustomerNameViewModel> viewModels = session.Query<Customer>()
        .TransformWith<CustomerNameTransformer, CustomerNameViewModel>()
        .ToList();
