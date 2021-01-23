    public SEL_PG_C_ALIViewModel(ICAD_EF_C_ALIService cadEfCAliService)
        {
            _cadEfCAliService = cadEfCAliService;
            IsDataLoaded = false;
            OnLoaded = new RelayCommand(OnLoadedExecute);
            Gerar = new RelayCommand(GerarExecute, GerarCanExecute);
            CodigoChecked = true;
        }
