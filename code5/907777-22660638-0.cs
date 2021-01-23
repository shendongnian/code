    public async void InitializeTransporterForm(Transporter enumerable)
    {
         TransporterFormVM = new TransporterFormViewModel(navigationService, enumerable);
         this.Parameter = enumerable; //setting the Parameter property..
         await SetUpForm(enumerable);
    }
