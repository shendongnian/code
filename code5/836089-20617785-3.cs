    BGWUpdateUi.ProgressChanged += (sender, args) =>
    {
        Application.Current.Dispatcher.BeginInvoke(new Action( () => {
            ProgressBarValue += args.ProgressPercentage;
            ((SelectedDwgFile)args.UserState).Status = "Completed";
        } ));
    };
