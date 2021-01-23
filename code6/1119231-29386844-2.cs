    private async Task SetupViewModels()
        {
            await Task.Factory.StartNew(() =>
            {
                ViewModelLocator locator = (ViewModelLocator)App.Current.Resources["Locator"];
                LoginWindowViewModel.objFicheViewModel = locator.FicheViewModel;
                LoginWindowViewModel.objFormationsViewModel = locator.FormationsViewModel;
                LoginWindowViewModel.objFacturationViewModel = locator.FacturationViewModel;
                LoginWindowViewModel.objGestionDPCViewModel = locator.GestionDPCViewModel;
                LoginWindowViewModel.objGestionGDPViewModel = locator.GestionGDPViewModel;
            });
        }
