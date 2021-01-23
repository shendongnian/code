        [Import]
        public ExportFactory<PopupViewModel> PopupViewModelFactory { get; set; }
        public void StartApp()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            PopupViewModel newPopup = this.PopupViewModelFactory.CreateExport().Value;
            IoC.Get<IWindowManager>().ShowWindow(newPopup);
        }
