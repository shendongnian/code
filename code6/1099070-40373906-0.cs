    public ICommand NavigationList { get; set; }
    NavigationList = new Command(GetListview);  
    public void  GetListview()
    {
       Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new ListViewPerson());
    }
