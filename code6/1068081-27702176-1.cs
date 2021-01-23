    public void ExecuteAddCommand()
    {
       MessengerInstance.Send<LocationModel>(LocationModelObj);
       _navigationService.navigate(tyepof(LocationPage));
    }
