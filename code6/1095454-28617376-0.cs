    void GetPrograms()
    {        
        var prgms = DataService.GetProgramList(SearchStringProgram);
        ListPrograms=new ObservableCollection<Program>(prgms);
        foreach (var prg in ListPrograms)
        {
            prg.SalesPrices.CollectionChanged += SalesPrices_CollectionChanged;
            foreach (SalesPrice item in prg.SalesPrices)
            {
                item.PropertyChanged += SalePrice_PropertyChanged;
            }
        }
    }
