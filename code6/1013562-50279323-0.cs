    public YourViewModel()
    {
        ButtonClickCommand= new Command(ButtonClicked);
    }
    private async void ButtonClicked(object sender)
    {
        var view = sender as Xamarin.Forms.Button;
    }
