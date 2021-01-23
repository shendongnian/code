    var repository = container.GetInstance<IBodInquiryRepository>();
    var res = await repository.GetFiltersForInquiries(84);
    var container = new Container();
    container.RegisterSingle<IBodInquiryRepository>(new BodInquiryRepository());
    container.RegisterSingle<FilterResponse>(res);
