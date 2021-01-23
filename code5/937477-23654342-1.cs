    public void DoAddressSearch(QueryMethodParameter p)
    {
      IAddressService addrService = (IAddressService)ApplicationController.GetInstance().ServiceFactory.GetService(typeof(Model.Address), this.ServiceContext);
      IListEx<Model.Address> erg = addrService.LoadAddresses(p);
      this.SetModel(erg);
      _viewItems = new AddressSearchViewItems(erg);
      this.ModelToView();
    }
